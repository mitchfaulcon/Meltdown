using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        highscore1 = PlayerPrefs.GetInt("highscore1", highscore1);
        scores.GetComponent<TMP_Text>().text = (highscore1.ToString() + "\n" +
            highscore2.ToString() + "\n" +
            highscore3.ToString() + "\n" +
            highscore4.ToString() + "\n" +
            highscore5.ToString());
    }

    void Update()
    {

    }

    // When a new score is awarded, check to see if it is a highscore
    public static bool recieveNewScore(int newScore)
    {
        // If the new score is a highscore, save it to player prefs
        if (newScore > highscore1)
        {
            highscore1 = newScore;
            PlayerPrefs.SetInt("highscore1", highscore1);
            PlayerPrefs.Save();

            return true;
        }
        else
        {
            return false;
        }
    }

    // Save player prefs on destroy
    void OnDestroy()
    {
        PlayerPrefs.SetInt("highscore1", highscore1);
        PlayerPrefs.Save();
    }

}
