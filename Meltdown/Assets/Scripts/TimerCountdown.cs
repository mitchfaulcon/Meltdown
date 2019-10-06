using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerCountdown : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    public float minutes = 1.5f;

    private float secondsRemaining;

    // Start is called before the first frame update
    void Start()
    {
        //Calculate total seconds in the countdown
        secondsRemaining = 60 * minutes;
    }

    // Update is called once per frame
    void Update()
    {

        if (secondsRemaining < 0)
        {
            EndGame();
        } else
        {
            //Only decrease countdown if it is above 0 to ensure display never goes negative
            secondsRemaining -= Time.deltaTime;
        }

        DisplayTime();
    }

    private int[] CalculateMinutesAndSeconds()
    {
        //Calculate the minutes & seconds based on seconds remaining
        int[] secondsAndMinutes = new int[2];

        secondsAndMinutes[0] = (int) secondsRemaining / 60;
        secondsAndMinutes[1] = (int) secondsRemaining % 60;

        return secondsAndMinutes;
    }

    private void EndGame()
    {
        //Enable cursor
        Cursor.visible = true;

        SceneManager.LoadScene("Level 1 Outro");
    }

    private void DisplayTime()
    {
        int[] secondsAndMinutes = CalculateMinutesAndSeconds();
        string minutes = secondsAndMinutes[0].ToString();
        string seconds = secondsAndMinutes[1].ToString();

        //Add a '0' to start of seconds if it is one digit (displays "1:04" instead of "1:4")
        if (seconds.Length == 1)
        {
            seconds = "0" + seconds;
        }

        string timeDisplay = minutes + ":" + seconds;
        timerText.text = timeDisplay;
    }

}
