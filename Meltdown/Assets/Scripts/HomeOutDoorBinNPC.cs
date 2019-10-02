using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeOutDoorBinNPC : NPCMovement
{
    private float userWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        // Set the NPC to wait on the first spot for 2 seconds
        userWaitTime = 2.0f; 

        // NPC starts off not moving. Only moves when triggered
        walking = false; 
    }

    // Update is called once per frame
    void Update()
    {
        // Set NPC to stop near the shed and the bin
        if (walking && (spot == 0 || spot == 5)) {
            waitTime = userWaitTime;
        } else if (spot == points.Length - 1 && (Vector3.Distance(transform.position, points[spot].position) < 1.0f)) {
            setWalking(false);
        } else {
            waitTime = 0;
        }
        Wait();
    }
}
