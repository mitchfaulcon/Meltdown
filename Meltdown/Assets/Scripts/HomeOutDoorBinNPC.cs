using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeOutDoorBinNPC : NPCMovement
{
    private float userWaitTime;
    private bool completed;
    private bool filled;

    // Start is called before the first frame update
    void Start()
    {
        // Set the NPC to wait on the first spot for 2 seconds
        userWaitTime = 2.0f; 

        // NPC starts off not moving. Only moves when triggered 
        completed = false;
        filled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (completed) {
            // Stop walking once the route is complete
            SetWalking(false);
            animator.SetBool("interact", false);
        } else if (walking && (spot == 0 || spot == 5)) { // Set NPC to stop near the shed and the bin
            waitTime = userWaitTime;
        } else {
            waitTime = 0;
        }

        if (spot == 6) { // When the NPC is stopped at the bin
            animator.SetBool("interact", true);
            ((RubbishTask) task).FillBin();
            filled = true;
        }

        // Set completed to false if it is not neat or at the final node
        completed = (Vector3.Distance(transform.position, points[points.Length - 1].position) < 1.0f) && filled;

        Wait();
    }
}
