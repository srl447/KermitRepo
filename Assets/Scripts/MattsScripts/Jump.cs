using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody _rigidbody;

    float jumpSpeed;
    public float jumpIncrease;

    public float gravity;

    bool isGrounded; //result of raycast below the player
    bool alreadyJumped = false; //has the player jumped?
    bool movementFinal = false;

    float jumpAllowTimer;

    public KeyCode jumpKey;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        jumpAllowTimer = 45f;
        jumpSpeed = 20f;
    }

    void Update()
    {
        //JUMPING
        if (Input.GetKey(jumpKey))
        {
            if (isGrounded && jumpAllowTimer > 0) 
            {
                -- jumpAllowTimer ;
                jumpSpeed += jumpIncrease;
            }
        }
        if (Input.GetKeyUp(jumpKey))
        {
            movementFinal = true;
        }
        
    }

    void FixedUpdate()
    {
        //DO GROUNDED CHECK: shoot raycast just a little past bottom of capsule
        if(Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }  
          
        if (movementFinal)
        {
            _rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            jumpSpeed = 20f;
            jumpAllowTimer = 60f;
            movementFinal = false;

        }
        else if (!isGrounded)
        {
            _rigidbody.AddForce(Vector3.down * gravity);
        }
    }
}
