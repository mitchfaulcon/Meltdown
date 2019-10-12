using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{   
    // Scene file names
    private static string LVL_1 = "Kitchen";
    private static string LVL_2 = "Backyard";
    private static string LVL_3 = "City";
    private static string LVL_1_INTRO = "HomeIntro";
    private static string LVL_2_INTRO = "BackyardIntro";
    private static string LVL_3_INTRO = "CityIntro";
    private static string LVL_1_OUTRO = "HomeOutro";
    private static string LVL_2_OUTRO = "BackyardOutro";
    private static string LVL_3_OUTRO = "CityOutro";
    private static string GAME_INTRO = "GameIntro";
    private static string GAME_OVER = "GameOver";
    private static string MAIN_MENU = "Main Menu";


    // The specified scene string to be opened is loaded my the 
    // scene manager when this method is called
    public void StartScene(string sceneToOpen)
    {
        // Load specified scene
        SceneManager.LoadScene(sceneToOpen);

    }

    public void Menu() {
        SceneManager.LoadScene(MAIN_MENU);
    }

    public void LoadLevel(int levelNumber) {
        switch (levelNumber)
      {
        case 1:
            SceneManager.LoadScene(LVL_1);
            break;
        case 2:
            SceneManager.LoadScene(LVL_2);
            break;
        case 3:
            SceneManager.LoadScene(LVL_3);
            break;
      }
    }

    public void LevelIntro(int levelNumber) {    
      switch (levelNumber)
      {
        case 1:
            SceneManager.LoadScene(LVL_1_INTRO);
            break;
        case 2:
            SceneManager.LoadScene(LVL_2_INTRO);
            break;
        case 3:
            SceneManager.LoadScene(LVL_3_INTRO);
            break;
      }
    }

    public void LevelOutro(int levelNumber) {
        switch (levelNumber)
      {
        case 1:
            SceneManager.LoadScene(LVL_1_OUTRO);
            break;
        case 2:
            SceneManager.LoadScene(LVL_2_OUTRO);
            break;
        case 3:
            SceneManager.LoadScene(LVL_3_OUTRO);
            break;
      }
    }

    public void GameIntro() {
        SceneManager.LoadScene(GAME_INTRO);
    }

    public void GameOutro() {
        SceneManager.LoadScene(GAME_OVER);
    }


}
