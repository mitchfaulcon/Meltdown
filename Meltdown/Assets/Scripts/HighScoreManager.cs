using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static int highscore;

    void Start()
    {

    }

    void Update()
    {

    }

    public static void recieveNewScore(int newScore)
    {
        if (newScore > highscore)
        {
            highscore = newScore;
            PlayerPrefs.SetInt("highscore", highscore);
            Debug.Log("New highscore set: " + highscore);
        }
    }

}
