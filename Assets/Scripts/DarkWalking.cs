using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWalking : MonoBehaviour {
    public float speed;
    bool leftmove;
    bool rightmove;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftmove = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rightmove = true;
        }
        else
        {
            leftmove = false;
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
        else if (rightmove)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
            transform.eulerAngles = new Vector3(0f, 0f, -10f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }
}

