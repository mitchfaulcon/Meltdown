using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeOutDoorBinNPC : NPCMovement
{
    private float userWaitTime;
    private bool completed;
    private bool filled;

    private bool binVisited;

    public GameObject toIgnore;
    
    void Start()
    {
        // Set the NPC to wait on the first spot for 2 seconds
        userWaitTime = 2.0f; 

        // NPC starts off not moving. Only moves when triggered 
        completed = false;
        filled = false;
        binVisited = false;

        Physics.IgnoreCollision(toIgnore.GetComponent<Collider>(), playerModel.GetComponent<Collider>());
    }

    void Update()
    {
        if (completed) {
            // Stop walking once the route is complete
            SetWalking(false);
        } else if (walking && (spot == 1 || spot == 5)) { // Set NPC to stop near the shed and the bin
            waitTime = userWaitTime;
        } else {
            waitTime = 0;
        }
        
        // When the NPC is stopped at the bin, fill the bin
        if (spot == 2) { 
            animator.SetBool("interact", true);
            ((RubbishTask) task).FillBin();
            binVisited = true;
        }

        // Set filled to true after the player starts walking away from the bin
        // so that interact animation stops playing.
        if (Vector3.Distance(transform.position, points[2].position) > 1.0f && binVisited) {
            filled = true;
            animator.SetBool("interact", false);
        }

        // Set completed to false if it is not neat or at the final node
        completed = (Vector3.Distance(transform.position, points[points.Length - 1].position) < 1.0f) && filled;

        Wait();
    }

    public void StartTask(Task toStart) {
        this.task = toStart;
        completed = false;
        filled = false;
        SetWalking(true);
    }
}
