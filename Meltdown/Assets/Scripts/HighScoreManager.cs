using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class HighScoreManager : MonoBehaviour
{
    public GameObject scores;

    public static List<int> highScoreList = new List<int>();

    public static int highscore1;
    public static int highscore2;
    public static int highscore3;
    public static int highscore4;
    public static int highscore5;

    // On start, get current high scores and set the high score screen to display as text
    void Start()
    {
        // Init top 5 high scores
        highscore1 = PlayerPrefs.GetInt("highscore1", highscore1);
        highscore2 = PlayerPrefs.GetInt("highscore2", highscore2);
        highscore3 = PlayerPrefs.GetInt("highscore3", highscore3);
        highscore4 = PlayerPrefs.GetInt("highscore4", highscore4);
        highscore5 = PlayerPrefs.GetInt("highscore5", highscore5);

        // Write highscores to the highscore list
        highScoreList.Add(highscore1);
        highScoreList.Add(highscore2);
        highScoreList.Add(highscore3);
        highScoreList.Add(highscore4);
        highScoreList.Add(highscore5);

        highScoreList = highScoreList.Distinct().ToList();

        highScoreList.Add(0);
        highScoreList.Add(0);
        highScoreList.Add(0);
        highScoreList.Add(0);
        highScoreList.Add(0);

        highScoreList.Sort();
        highScoreList.Reverse();

        // Display top 5 high scores on the highscore board
        scores.GetComponent<TMP_Text>().text = (highScoreList[0].ToString() + "\n" +
            highScoreList[1].ToString() + "\n" +
            highScoreList[2].ToString() + "\n" +
            highScoreList[3].ToString() + "\n" +
            highScoreList[4].ToString());
    }

    void Update()
    {

    }

    // When a new score is awarded, check to see if it is a highscore
    public static bool recieveNewScore(int newScore)
    {
        // If the new score is a highscore, save it to player prefs
        for (int i = highScoreList.Count - 1; i >= 0; i--)
        {
            if (newScore > highScoreList[i])
            {
                highScoreList[i] = newScore;
                highScoreList = highScoreList.Distinct().ToList();

                highScoreList.Add(0);
                highScoreList.Add(0);
                highScoreList.Add(0);
                highScoreList.Add(0);
                highScoreList.Add(0);

                highScoreList.Sort();
                highScoreList.Reverse();

                PlayerPrefs.SetInt("highscore1", highScoreList[0]);
                PlayerPrefs.SetInt("highscore2", highScoreList[1]);
                PlayerPrefs.SetInt("highscore3", highScoreList[2]);
                PlayerPrefs.SetInt("highscore4", highScoreList[3]);
                PlayerPrefs.SetInt("highscore5", highScoreList[4]);
                PlayerPrefs.Save();

                if (i <= 5)
                {
                    return true;
                }
            }
        }

        return false;
    }

    // Save player prefs on destroy
    void OnDestroy()
    {
        PlayerPrefs.SetInt("highscore1", highScoreList[0]);
        PlayerPrefs.SetInt("highscore2", highScoreList[1]);
        PlayerPrefs.SetInt("highscore3", highScoreList[2]);
        PlayerPrefs.SetInt("highscore4", highScoreList[3]);
        PlayerPrefs.SetInt("highscore5", highScoreList[4]);
        PlayerPrefs.Save();
    }

}
