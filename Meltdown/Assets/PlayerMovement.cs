using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private const float DEFAULT_SPEED = 300f;
    private const float SPRINT_SPEED = 500f;
    // Public variables can be changed in unity editor
    public float movementSpeed = DEFAULT_SPEED;
    public new Rigidbody rigidbody;

    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            //Move in positive z direction
            movement.z = 1;
        }
        if (Input.GetKey("s"))
        {
            //Move in negative z direction
            movement.z = -1;
        }
        if (Input.GetKey("a"))
        {
            //Move in negative x direction
            movement.x = -1;
        }
        if (Input.GetKey("d"))
        {
            //Move in positive x direction
            movement.x = 1;
        }
        if (Input.GetKey("left shift"))
        {
            movementSpeed = SPRINT_SPEED;
        }
        if (Input.GetKeyUp("left shift"))
        {
            movementSpeed = DEFAULT_SPEED;
        }
    }

    // FixedUpdate for physics actions
    private void FixedUpdate()
    {
        movement.Normalize();
        //rigidbody.MovePosition(rigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);
        rigidbody.velocity = movement * movementSpeed * Time.fixedDeltaTime;
        movement.x = 0;
        movement.z = 0;
    }
}
