using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCountdown : MonoBehaviour
{

    public TextMeshProUGUI countdownText;
    public GameObject countdownPanel;

    public AudioSource gameMusic;
    public AudioSource countdownSound;

    private void Start()
    {
        Time.timeScale = 0f; //Freeze game
        countdownText.text = "3"; //Start countdown text at 3

        if (GameSettings.sounds)
        {
            //Plays beeping sound
            countdownSound.Play();
        }
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        for (int i = 2; i >= 0; i--)
        {
            //Wait for one second (can't use WaitForSeconds() as timeScale is 0)
            float calledTime = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup - calledTime < 1)
            {
                yield return null;
            }

            countdownText.text = i.ToString();
        }
        StartGame();
    }

    private void StartGame()
    {
        countdownSound.Stop(); //Just in case
        Time.timeScale = 1f;
        // Start game music if enabled
        if (GameSettings.music == true)
        {
            gameMusic.Play();
        }

        //Hide the countdown
        countdownPanel.SetActive(false);
    }
}
