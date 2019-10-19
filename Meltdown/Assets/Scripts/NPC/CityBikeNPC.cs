using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBikeNPC : NPCMovement
{
    public Animator[] doorAnimators;
    public Animator taxiAnimator;

    public GameObject bike;
    private bool taxiReached;
    private bool bikeGiven;
    private Material material;

    private const float SLOW_SPEED = 1.33f;
    private const float FAST_SPEED = 7.0f;

    private BikeNPC bikeTask;
    private float taxiTimer = 0.0f;

    public CityPlayerInteraction player;


    void Start()
    {
        movementSpeed = SLOW_SPEED;
        SetWalking(false);
        bike.SetActive(false);        
        taxiReached = false;
        bikeGiven = false;
        threshhold = 1.0f;

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
        if (Vector3.Distance(transform.position, points[2].position) < 1.0f && !bikeGiven) 
        {
            taxiReached = true;
        }

        // If the player did give him the bike and the NPC reaches off screen
        if (bikeGiven) {
            transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);

            if (Vector3.Distance(transform.position, points[points.Length-1].position) < 2.0f) 
            {
                bikeTask.CompleteTask();
                SetBiking(false);
                ResetPosition();
            }
        }
        
        //TODO make x appear above taxi head indicating person was too slow
        if (taxiReached) {
            SetWalking(false);
            
            taxiTimer += Time.deltaTime;

            // Let the NPC stand for 2 seconds before the taxi leaves, allowing the player
            // to still give him the bike
            if (taxiTimer > 2.0f) {
                taxiTimer = 0.0f;

                player.setItem(ItemTypes.NONE);
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

        // Reset Variables
        bikeGiven = false;
        taxiReached = false;
        spot = 0;
        threshhold = 1.0f;
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

    private void SetBiking(bool biking) {
        float y = transform.position.y;

        if (biking) {
            y += 0.5f;
            SetWalking(true);
        }

        bike.SetActive(biking);
        animator.SetBool("biking", biking);

    }

    public void GiveBike() 
    {
        bikeGiven = true;
        taxiReached = false;
        SetBiking(true);
        threshhold = 2.0f;
        movementSpeed = FAST_SPEED;
    }
}
