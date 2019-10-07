using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseMenuCards;
    public GameObject helpMenuCards;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        //Disable pause menu UI
        pauseMenuUI.SetActive(false);
        pauseMenuCards.SetActive(false);
        helpMenuCards.SetActive(false);

        //Hide mouse cursor
        Cursor.visible = false;

        Time.timeScale = 1f; //Un-pause time
        isPaused = false;
    }

    void Pause()
    {
        //Enable pause menu UI
        pauseMenuUI.SetActive(true);
        pauseMenuCards.SetActive(true);
        helpMenuCards.SetActive(false);

        //Mouse cursor visible
        Cursor.visible = true;

        Time.timeScale = 0f; //Pause time
        isPaused = true;
    }

    public void BackToMenu()
    { 
        Time.timeScale = 1f; //Un-pause time
        SceneManager.LoadScene("Main Menu");
    }
}
