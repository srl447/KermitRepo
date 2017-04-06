using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public float speed;
    bool leftmove;
    bool rightmove;
    bool flipped;

    public KeyCode LeftCode;
    public KeyCode RightCode;

    public GameObject otherPlayer;

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
            bool flipped = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180f, transform.eulerAngles.z);
            bool flipped = true;
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
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 10f);
            }
            else
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -350f);
            }
        }
        if (rightmove)
        {

            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);

            // TILT CODE
            if (flipped)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -10f);
            }
            else
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 350f);
            }

        }
        if (!leftmove && !rightmove)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        }
    }
}
