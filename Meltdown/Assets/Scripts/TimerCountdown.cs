using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    public float minutes = 1.5f;
    public Image scoreBar;
    public AudioSource endBellSound;
    public AudioSource gameMusic;
    public GameObject timeUpPanel;

    private float secondsRemaining;
    public static bool gameFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        //Calculate total seconds in the countdown
        secondsRemaining = 60 * minutes;
    }

    // Update is called once per frame
    void Update()
    {
        //Cheat to end game early
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.E))
        {
            LoadOutro();
        }
        if (secondsRemaining < 0 && !gameFinished)
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
        secondsAndMinutes[1] = (int) Mathf.Ceil(secondsRemaining % 60);

        if (secondsAndMinutes[1] == 60)
        {
            secondsAndMinutes[1] = 00;
            secondsAndMinutes[0]++;
        }

        return secondsAndMinutes;
    }

    private void EndGame()
    {
        //Set game to finished & freeze
        gameFinished = true;
        Time.timeScale = 0f;

        //Display time up panel
        timeUpPanel.SetActive(true);

        //Stop the music 
        gameMusic.Stop();
        //Play bell if sound effects setting is enabled
        if (GameSettings.sounds == true)
        {
            endBellSound.Play();
        }

        StartCoroutine(LoadPostLevel());
    }

    IEnumerator LoadPostLevel()
    {
        //while loop to wait for 3 seconds for bell sound to finish (cannot use WaitForSeconds(3) as time is frozen)
        float calledTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - calledTime < 3)
        {
            yield return null;
        }

        LoadOutro();
    }

    private void LoadOutro()
    {
        //Calculate score based on thermometer
        float score = scoreBar.fillAmount;

        Score.GetInstance().SetPoints(score);

        //Enable cursor
        Cursor.visible = true;

        //Unfreeze time
        Time.timeScale = 1f;

        // Load appropriate post scene
        if (SceneManager.GetActiveScene().name == "Kitchen")
        {
            SceneManager.LoadScene("HomeOutro");
        }
        else if (SceneManager.GetActiveScene().name == "Backyard")
        {
            SceneManager.LoadScene("BackyardOutro");
        }
        else if (SceneManager.GetActiveScene().name == "City")
        {
            SceneManager.LoadScene("CityOutro");
        }



        //Set gameCompleted to false to prevent bugs when trying again
        gameFinished = false;
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
