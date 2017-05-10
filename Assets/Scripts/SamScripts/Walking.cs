using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public float speed;
    bool leftmove;
    bool rightmove;
    public bool flipped;

    public KeyCode LeftCode;
    public KeyCode RightCode;

    public GameObject otherPlayer;

	public Animator kermitAnimator;

    private void Start()
    {
        otherPlayer = GameObject.FindGameObjectWithTag(tag == "kermit" ? "darkKermit" : "kermit");
    }

    void Update ()
    {
        leftmove = Input.GetKey(LeftCode);
        rightmove = Input.GetKey(RightCode);

        if (otherPlayer.transform.position.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0f, transform.eulerAngles.z);
            flipped = false;
        }
        else if(otherPlayer.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180f, transform.eulerAngles.z);
           flipped = true;
        }
    }

    void FixedUpdate()
    {
        if (leftmove)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
            // TILT CODE
            if (flipped)
            {
                //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -5f);
                kermitAnimator.SetInteger("State", 2);
            }
            else
            {
                //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 5f);
                kermitAnimator.SetInteger("State", 1);
            }
        }
        if (rightmove)
        {

            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
            // TILT CODE
            if (flipped)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 5f);
                kermitAnimator.SetInteger("State", 1);
            }
            else
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -5f);
                kermitAnimator.SetInteger("State", 2);
            }

        }
        if (!leftmove && !rightmove)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
			kermitAnimator.SetInteger ("State", 0);
        }
    }
}
