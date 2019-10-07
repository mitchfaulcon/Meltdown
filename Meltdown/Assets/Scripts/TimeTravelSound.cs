using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelSound : MonoBehaviour
{
    public AudioSource portalSound;

    // Start is called before the first frame update
    void Start()
    {
        if (GameSettings.sounds == true)
        {
            portalSound.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
