using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public static int highscore;

    public GameObject scores;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        scores.GetComponent<TMP_Text>().text = highscore.ToString();
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

    void OnDestroy()
    {
        PlayerPrefs.SetInt("highscore", highscore);
        PlayerPrefs.Save();
    }

}
