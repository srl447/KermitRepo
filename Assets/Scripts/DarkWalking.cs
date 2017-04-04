using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWalking : MonoBehaviour {
    public float speed;
    bool leftmove;
    bool rightmove;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftmove = true;
        }
        else
        {
            leftmove = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightmove = true;
        }
        else
        {
            rightmove = false;
        }

    }

    void FixedUpdate()
    {
        if (leftmove)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
            transform.eulerAngles = new Vector3(0f, 0f, 10f);
        }
        if (rightmove)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
            transform.eulerAngles = new Vector3(0f, 0f, -10f);
        }

    }
}

