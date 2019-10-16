using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Slider slider;
    public string levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        //Stop playing dialogue music if it is playing
        try
        {
            GameObject.FindGameObjectWithTag("DialogueMusic").GetComponent<DialogueMusicController>().StopMusic();
        }
        catch (System.NullReferenceException)
        {
        }

        //Start loading scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToLoad);

        //Update progress bar until level finishes loading
        while (!operation.isDone)
        {
            //Fix between 0 & 1
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            yield return null;
        }
    }
}
