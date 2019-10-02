using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {
	private const float DEFAULT_SPEED = 5f;

	public float movementSpeed = DEFAULT_SPEED;
	
	// Points are places where NPC will move towards
	public Transform[] points;
	protected int spot;
	
	public Rigidbody rigidBody;
	
	public bool walking = true;

	public float waitTime;
	private float waitCounter;

	public float rotateSpeed = 20f;
	public GameObject playerModel;
	public Animator animator;
	
  // Start is called before the first frame update
  	void Start() {
		spot = 0;
		waitCounter = waitTime;
  	}

  // Update is called once per frame
  	void Update() {
		Wait();
	}

	protected void Wait() {
		// Check if NPC is near the point before decrementing wait counter
		if ((Vector3.Distance(transform.position, points[spot].position) < 1.0f) && walking) {
			if (waitCounter <= 0) {
				// Increment spots to move towards next spot, reset after last spot
				if (spot == points.Length - 1) {
					spot = 0;
				} else {
					spot++;
				}

				// Reset wait counter
				waitCounter = waitTime;
			} else {
				waitCounter -= Time.deltaTime;
			}
		}
	}

	private void FixedUpdate() {
		if (walking) {
			// Move player and start animation when npc is moving
			transform.position = Vector3.MoveTowards(transform.position, points[spot].position, movementSpeed*Time.deltaTime);
			animator.SetFloat("velocity", Vector3.Distance(transform.position, points[spot].position) - 0.95f);

			// Rotate player model to direction of travel
			SetRotation(points[spot].position - transform.position);
		}
	}

	protected void SetRotation(Vector3 direction) {
		direction.y = 0f;
    	transform.rotation = Quaternion.Slerp(transform.rotation, 
								Quaternion.LookRotation(direction), 0.1f);
	}

	public void setWalking(bool walk) {
		walking = walk;
	}
}