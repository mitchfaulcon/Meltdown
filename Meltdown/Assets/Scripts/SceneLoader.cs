using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public string sceneToOpen;

    // The specified scene string to be opened is loaded my the 
    // scene manager when this method is called
    public void StartScene()
    {
        // Load specified scene
        SceneManager.LoadScene(sceneToOpen);

    }
}
