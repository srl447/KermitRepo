using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSlap : MonoBehaviour {

    void OnCollisionStay(Collision col)
    {
        Debug.Log(name.ToString() + " GOT HIT");
    }
}
