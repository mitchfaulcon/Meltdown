using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        // Load the level 1 intro
        SceneManager.LoadScene("Level 1 Intro");
    }

    public void quitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
