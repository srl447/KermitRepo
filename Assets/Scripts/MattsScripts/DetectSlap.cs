using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSlap : MonoBehaviour {

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "slap")
        {
            Debug.Log(name.ToString() + " GOT HIT");
        }
    }
}
