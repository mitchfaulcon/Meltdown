using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {
	private const float DEFAULT_SPEED = 5f;

	public float movementSpeed = DEFAULT_SPEED;
	
	// Points are places where NPC will move towards
	public Transform[] points;
	private int spot;
	
	public Rigidbody rigidBody;
	
	public bool isWalking;

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
		// Check if NPC is near the point before decrementing wait counter
		if (Vector3.Distance(transform.position, points[spot].position) < 1.0f) {
	
			if (waitCounter <= 0) {
				// Increment spots to move towards next spot
				if (spot+1 == points.Length) {
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
		transform.position = Vector3.MoveTowards(transform.position, points[spot].position, movementSpeed*Time.deltaTime);
		animator.SetFloat("velocity", Vector3.Distance(transform.position, points[spot].position) - 0.95f);
    
		//Rotate player model to direction of travel
		
		Vector3 dir = points[spot].position - transform.position;
		dir.y = 0f;
    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.1f);
	
	}
}