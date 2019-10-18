using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelSound : MonoBehaviour
{
    public AudioSource portalSound;

    // Start is called before the first frame update
    // Play the portal sound if it is enabled
    void Start()
    {
        if (GameSettings.sounds == true)
        {
            portalSound.Play();
        }
    }

    void Update()
    {
        
    }
}
