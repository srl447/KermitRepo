﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rbodyDarK;

    public float jumpSpeed;

    bool isGrounded; //result of raycast below the player
    bool alreadyJumped = false; //has the player jumped?

    float jumpAllowTimer;

    void Start()
    {
        rbodyDarK = GetComponent<Rigidbody>();
        jumpAllowTimer = 2f;

    }


    void Update()
    {


        //JUMPING
        if (Input.GetKey(KeyCode.Q))
        {
            if (isGrounded || jumpAllowTimer > 0) //could use transform.position.y as a constraint instead of IsGrounded
            {
                rbodyDarK.transform.Translate(0f, jumpSpeed, 0f);
                jumpAllowTimer -= Time.deltaTime;
            }
        }
        else
        {
            jumpAllowTimer = 2f;
        }

        //if(alreadyJumped == true)
        //{
        //    jumpAllowTimer -= 1f;
        //    if(jumpAllowTimer <= 0)
        //    {
        //        alreadyJumped = false;
        //        jumpAllowTimer = 50f;
        //    }
        //}
    }

    void FixedUpdate()
    {

        //DO GROUNDED CHECK: shoot raycast just a little past bottom of capsule
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
