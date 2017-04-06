using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDark : MonoBehaviour
{
    Rigidbody rbodyDarK;

    public float jumpSpeed;

    bool isGrounded; //result of raycast below the player
    bool alreadyJumped = false; //has the player jumped?
    bool movementFinal = false;

    float jumpAllowTimer;

    void Start()
    {
        rbodyDarK = GetComponent<Rigidbody>();
        jumpAllowTimer = 2f;
    }


    void Update()
    {
        //JUMPING
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (jumpAllowTimer > 0)
            {
                movementFinal = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            jumpAllowTimer = 0;
        }
    }

    void FixedUpdate()
    {
        //DO GROUNDED CHECK: shoot raycast just a little past bottom of capsule
        if(Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            jumpAllowTimer = .15f;
        }
        if(movementFinal)
        {
            rbodyDarK.transform.Translate(0f, jumpSpeed, 0f);
            jumpAllowTimer -= Time.deltaTime;
            movementFinal = false;
        }
    }
}
