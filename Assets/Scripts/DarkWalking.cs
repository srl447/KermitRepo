using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWalking : MonoBehaviour {
    public float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
            transform.eulerAngles = new Vector3(0f, 0f, 10f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
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

