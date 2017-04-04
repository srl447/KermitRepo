using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyController : MonoBehaviour {

    Rigidbody rbody; // var to store player Rigidbody

    Vector3 inputVector; //var we use to pass info from Update -> FixedUpdate

    public float moveSpeed;
    public float jumpSpeed;

    bool isGrounded; //result of raycast below the player
    bool alreadyJumped = false; //has the player jumped?

    public float maxSpeed = 5f;

	void Start () {
        rbody = GetComponent<Rigidbody>(); //cache reference for our shortcut
	}
	
    //get player input in Update()
    //If you were to move camera inside player, this could work as a first person game!!!
	void Update () {
        //MOVEMENT
        float horizontal = Input.GetAxis("Horizontal"); // Left/Right, A/D
        float vertical = Input.GetAxis("Vertical"); // Up/Down, W/S 

        inputVector = new Vector3(horizontal, 0f, vertical);

        //TURNING
        transform.Rotate(0f, Input.GetAxis("Mouse X") * Time.deltaTime * 180f, 0f);
        
        //JUMPING
        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        //{
        //    inputVector.y = jumpSpeed;
        //    alreadyJumped = true;
        //}
	}

    //this is the framerate where PHYSICS runs
    void FixedUpdate ()
    {
        //if (alreadyJumped == false)
        //{
        //    inputVector.y = 0f;
        //}
        ////jump separately
        //rbody.AddRelativeForce(Vector3.up * inputVector.y * moveSpeed);

        //apply X/Z movement
        if(rbody.velocity.magnitude < maxSpeed)
        {
            rbody.AddRelativeForce(inputVector * moveSpeed); // AddForce and AddRelativeForce are good for movement
        }

        //DO GROUNDED CHECK: shoot raycast just a little past bottom of capsule
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
