using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMusicController : MonoBehaviour
{

    public AudioSource introMusic;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        introMusic = GetComponent<AudioSource>();
    }

    // Play music if it is enabled and not already doing so
    public void PlayMusic()
    {
        if (!introMusic.isPlaying && GameSettings.music == true)
        {
            introMusic.Play();
        }
    }

    public void StopMusic()
    {
        introMusic.Stop();
    }
}
