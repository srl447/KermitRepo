using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slap : MonoBehaviour
{
    public GameObject Player1HitBox;
    public GameObject Player2HitBox;
    public GameObject Player1;
    public GameObject Player2;

    public float Player1AttackCooldown;
    public float Player2AttackCooldown;

    public int Player1AttackFrameCountdown;
    public int Player2AttackFrameCountdown;

    public bool player1IsSlapping;
    public bool player2IsSlapping;
	
	void Update () {
	    if (Input.GetKeyDown(KeyCode.LeftShift))
	    {
	        if (Player1AttackFrameCountdown == 0)
	        {
                StartCoroutine(Player1Slap());
            }
	    }
	    if (Input.GetKeyDown(KeyCode.RightShift))
	    {
	        if (Player2AttackFrameCountdown == 0)
	        {
                StartCoroutine(Player2Slap());
            }
        }
	}

    IEnumerator Player1Slap()
    {
        Player1AttackFrameCountdown = 4;
        Player1HitBox.SetActive(true);
        Player1.GetComponent<Collider>().enabled = false;
        while (Player1AttackFrameCountdown > 0)
        {
            --Player1AttackFrameCountdown;
            yield return new WaitForEndOfFrame();
        }
        Player1HitBox.SetActive(false);
        Player1.GetComponent<Collider>().enabled = true;
    }

    IEnumerator Player2Slap()
    {
        Player2AttackFrameCountdown = 4;
        Player2HitBox.SetActive(true);
        Player2.GetComponent<Collider>().enabled = false;
        while (Player2AttackFrameCountdown > 0)
        {
            --Player2AttackFrameCountdown;
            yield return new WaitForEndOfFrame();
        }
        Player2HitBox.SetActive(false);
        Player2.GetComponent<Collider>().enabled = true;
    }
}
