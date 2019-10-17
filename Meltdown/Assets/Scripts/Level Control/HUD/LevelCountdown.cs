using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCountdown : MonoBehaviour
{

    public TextMeshProUGUI countdownText;
    public GameObject countdownPanel;

    public AudioSource gameMusic;

    private void Start()
    {
        Time.timeScale = 0f;
        countdownText.text = "3";

        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        for (int i = 2; i >= 0; i--)
        {
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
        Time.timeScale = 1f;
        // Start game music if enabled
        if (GameSettings.music == true)
        {
            gameMusic.Play();
        }
        countdownPanel.SetActive(false);
    }
}
