using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slap : MonoBehaviour
{
    public GameObject HitBox;
    public GameObject DownHitBox;
    public float AttackCooldown;
    public int AttackFrameCountdown;
    public bool IsSlapping;

    public KeyCode slapKey;



    void Update () {
	    if (Input.GetKeyDown(slapKey))
	    {
	        if (AttackFrameCountdown == 0)
	        {
                StartCoroutine(SlapAction());
            }
	    }
        
	}

    IEnumerator SlapAction()
    {
        AttackFrameCountdown = 4;
        HitBox.SetActive(true);
        GetComponent<Collider>().enabled = false;
        while (AttackFrameCountdown > 0)
        {
            --AttackFrameCountdown;
            yield return new WaitForEndOfFrame();
        }
        HitBox.SetActive(false);
        GetComponent<Collider>().enabled = true;
    }
}
