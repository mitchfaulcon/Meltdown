using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBikeNPC : NPCMovement
{
    public Animator[] doorAnimators;
    public Animator taxiAnimator;
    private bool taxiReached;
    private bool bikeGiven;
    private Material material;

    private const float SLOW_SPEED = 2.0f;
    private const float FAST_SPEED = 7.0f;

    private BikeNPC bikeTask;

    void Start()
    {
        movementSpeed = SLOW_SPEED;
        SetWalking(false);
        
        taxiReached = false;
        bikeGiven = false;

        material = gameObject.GetComponent<MeshRenderer>().material;
        bikeTask = this.GetComponent<BikeNPC>();

        GameObject[] walls = GameObject.FindGameObjectsWithTag("InvisWall");
        foreach (GameObject wall in walls)
        {
            Physics.IgnoreCollision(wall.GetComponent<Collider>(), playerModel.GetComponent<Collider>());
        }
    }

    void Update()
    {
        // If the NPC reaches the taxi and the player didn't give him the bike
        if (Vector3.Distance(transform.position, points[3].position) < 1.0f && !bikeGiven) 
        {
            taxiReached = true;
        }

        // If the player did give him the bike and the NPC reaches off screen
        if (bikeGiven && Vector3.Distance(transform.position, points[points.Length-1].position) < 1.0f) 
        {
            bikeTask.CompleteTask();
            ResetPosition();
        }

        if (taxiReached) {
            SetWalking(false);
            
            // Slowly make NPC transparent
            if (material.color.a > 0)
            {
                Color newColor = material.color;
                newColor.a -= Time.deltaTime;
                material.color = newColor;
                gameObject.GetComponent<MeshRenderer>().material = material;
            } 
            else 
            {
                ResetPosition();
                bikeTask.FailTask();
                taxiAnimator.SetTrigger("play");
            }            
        }

        Wait();
    }

    private void ResetPosition() 
    {
        SetWalking(false);

        // Teleport NPC back to starting position
        transform.position = new Vector3(
        points[0].position.x,
        transform.position.y,
        points[0].position.z);

        bikeGiven = false;
        taxiReached = false;
        spot = 0;
        movementSpeed = SLOW_SPEED;
    }

    public void StartTask() 
    {
        SetDoors(true);
        SetWalking(true);

        StartCoroutine(CloseDoors());
    }

    private IEnumerator CloseDoors() {
        yield return new WaitForSeconds(1);
        SetDoors(false);
    }

    private void SetDoors(bool open) {
        foreach(Animator doorAnim in doorAnimators) 
        {
            doorAnim.SetBool("open", open);
        }
    }

    public void GiveBike() 
    {
        bikeGiven = true;
        movementSpeed = FAST_SPEED;
    }
}
