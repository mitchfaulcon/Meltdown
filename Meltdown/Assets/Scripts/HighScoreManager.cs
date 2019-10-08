using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public static int highscore;
    public GameObject scores;


    // On start, get current high scores and set the high score screen to display as text
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        scores.GetComponent<TMP_Text>().text = highscore.ToString();
    }

    void Update()
    {

    }

    // When a new score is awarded, check to see if it is a highscore
    public static bool recieveNewScore(int newScore)
    {
        // If the new score is a highscore, save it to player prefs
        if (newScore > highscore)
        {
            highscore = newScore;
            PlayerPrefs.SetInt("highscore", highscore);
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
        PlayerPrefs.SetInt("highscore", highscore);
        PlayerPrefs.Save();
    }

}
