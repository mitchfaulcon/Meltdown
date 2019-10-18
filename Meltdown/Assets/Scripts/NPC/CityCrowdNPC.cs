using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CityCrowdNPC : NPCMovement
{
    private float xPos;

    public Transform startPos;
    public void Start()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("InvisWall");
        foreach (GameObject wall in walls)
        {
            Physics.IgnoreCollision(wall.GetComponent<Collider>(), playerModel.GetComponent<Collider>());
        }
        walking = true;
        xPos = transform.position.x;
        
    }

    void Update()
    {
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

        if (Math.Abs(transform.position.z - points[0].position.z) < 1.0f) {
            // Wait a random amount of time before starting to walk again
            waitTime = UnityEngine.Random.Range(0, 5);

            // Randomly generate the X value of the NPC to fit within the street
            xPos = UnityEngine.Random.Range(6.0f, 15.0f); 

            Vector3 temp = new Vector3(
                xPos, transform.position.y, 
                startPos.position.z);     // Teleport the NPC back to the bottom of the street
            
            transform.position = temp;
        }

        Wait();
    }
}
