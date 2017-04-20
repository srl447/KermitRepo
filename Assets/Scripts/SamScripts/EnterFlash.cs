using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterFlash : MonoBehaviour
{
    int timer;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame

    void FixedUpdate ()
    {
        if (timer == 30)
        {
            transform.position += new Vector3(0, -200f, 0);
        }
        else if (timer == 60)
        {
            transform.position += new Vector3(0, 200f, 0);
            timer = 0;
        }
        timer++;
	}
}
