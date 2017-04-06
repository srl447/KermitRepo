using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDeath : MonoBehaviour {

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Edge")
        {
            Debug.Log("You Died");
        }
    }
}
