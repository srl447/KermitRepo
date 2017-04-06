using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour {
    public float speed;
    bool leftmove;
    bool rightmove;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.A))
        {
            leftmove = true;
        }
        else
        {
            leftmove = false;
        }
        if (Input.GetKey(KeyCode.D))
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
            transform.eulerAngles = new Vector3(0f, 180f, 10f);
        }
        if (!leftmove && !rightmove)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        }
    }
}
