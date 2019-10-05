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
	
	public bool walking;

	public float waitTime;
	private float waitCounter;

	public float rotateSpeed = 20f;
	public GameObject playerModel;
	public Animator animator;
	protected Task task;

  // Start is called before the first frame update
  	void Start() {
		walking = false;
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
			MovePlayer(points[spot].position);
			SetRotation(points[spot].position - transform.position);
			
		}
	}


	protected void MovePlayer(Vector3 dest) {
		// Move player and start animation when npc is moving
		transform.position = Vector3.MoveTowards(transform.position, dest, movementSpeed*Time.deltaTime);
		animator.SetFloat("velocity", Vector3.Distance(transform.position, dest) - 0.95f);
	}
	protected void SetRotation(Vector3 direction) {
		// Rotate player model to direction of travel
		direction.y = 0f;
		if (direction.x != 0 || direction.z != 0) {
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);
		}
    	
	}

	public void SetWalking(bool walk) {
		walking = walk;
	}

	public void SetTask(Task t) {
		task = t;
	}
} 