using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    public void BackToMenu()
    {   
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

}
