﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public float jumpSpeed;

    bool isGrounded; //result of raycast below the player
    bool alreadyJumped = false; //has the player jumped?
    bool movementFinal = false;

    float jumpAllowTimer;

    public KeyCode jumpKey;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        jumpAllowTimer = .15f;
    }

    void Update()
    {
        //JUMPING
        if (Input.GetKey(jumpKey))
        {
            if (jumpAllowTimer > 0 && isGrounded) //could use transform.position.y as a constraint instead of IsGrounded
            {
              movementFinal = true;
            }
        }
        if (Input.GetKeyUp(jumpKey))
        {
            isGrounded = false;
        }

        if (jumpAllowTimer <= 0)
        {
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        //DO GROUNDED CHECK: shoot raycast just a little past bottom of capsule
        if(Physics.Raycast(transform.position, Vector3.down, 1f))
            {
                jumpAllowTimer = .15f;
                isGrounded = true;
            }   
            
        if (movementFinal)
        {
            _rigidbody.transform.Translate(0f, jumpSpeed, 0f);
            jumpAllowTimer -= Time.deltaTime;
            movementFinal = false;
        }
    }
}