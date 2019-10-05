using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManager;

public class ButtonToMenuScript : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
