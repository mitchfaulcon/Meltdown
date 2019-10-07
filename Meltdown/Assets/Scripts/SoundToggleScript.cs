using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void toggle()
    {
        Debug.Log("Toggling");
        GameSettings.sounds = !GameSettings.sounds;
    }
}
