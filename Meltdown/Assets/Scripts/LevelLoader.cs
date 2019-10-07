using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsynchronously());
    }

    // Update is called once per frame
    IEnumerator LoadAsynchronously()
    {
        //Start loading scene
        AsyncOperation operation = SceneManager.LoadSceneAsync("Home_Outdoor");

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
