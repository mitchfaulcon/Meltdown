using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private const float DEFAULT_SPEED = 500f;

    // Public variables can be changed in unity editor
    public float movementSpeed = DEFAULT_SPEED;
    public Rigidbody rigidbody;
    public GameObject playerModel;
    public float rotateSpeed = 20f;
    public Animator animator;

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
    }

    // FixedUpdate for physics actions
    private void FixedUpdate()
    {
        //Move player
        movement.Normalize();
        rigidbody.velocity = movement * movementSpeed * Time.fixedDeltaTime;

        //Update animator field
        animator.SetFloat("velocity", rigidbody.velocity.magnitude);

        if (movement.x != 0 || movement.z != 0)
        {
            //Rotate player model to direction of travel
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(movement.x, 0f, movement.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.fixedDeltaTime);
        }

        movement.x = 0f;
        movement.z = 0f;
    }
}
