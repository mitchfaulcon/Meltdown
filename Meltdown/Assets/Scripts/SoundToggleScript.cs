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
        GameSettings.sounds = !GameSettings.sounds;
        Debug.Log("Toggling Sound " + GameSettings.sounds);
    }

    public void toggleMusic()
    {
        GameSettings.music = !GameSettings.music;
        Debug.Log("Toggling Music " + GameSettings.music);
    }
}
