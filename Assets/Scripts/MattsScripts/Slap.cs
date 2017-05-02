using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slap : MonoBehaviour
{
    public GameObject HitBox;
    public float AttackCooldown;
    private int _prepFrameCountdown;
    private int _attackFrameCountdown;
    private int _cooldownFrameCountdown;
    public bool IsSlapping;

    public KeyCode slapKey;

    public int _keyHoldCount;

    public Animator animator;
    private Walking _walkingScript;

    private int dir;

    private void Start()
    {
        _walkingScript = GetComponent<Walking>();
        dir = _walkingScript.flipped ? -1 : 1;
    }

    void Update () {
	    if (Input.GetKey(slapKey))
	    {
	        ++_keyHoldCount;
	    }
        if (Input.GetKeyUp(slapKey))
	    {
	        if (_keyHoldCount < 20)
	        {
                // Close Slap
                if (_cooldownFrameCountdown == 0)
                {
                    StartCoroutine(SlapAction("ShortSlap", 0f));
                }
            }
	        else
	        {
                // Far Slap
                if (_cooldownFrameCountdown == 0)
                {
                    StartCoroutine(SlapAction("LongSlap", .5f));
                }
            }
            _keyHoldCount = 0;
	    }
	}

    IEnumerator SlapAction(string animationTrigger, float scaleAdditive)
    {

        //LOGIC FOR TRIGGERING ANIMATION
        
        //animator.SetTrigger(animationTrigger);

        HitBox.transform.localScale = new Vector3(HitBox.transform.localScale.x, HitBox.transform.localScale.y + scaleAdditive, HitBox.transform.localScale.z);
        HitBox.transform.localPosition = new Vector3(HitBox.transform.localPosition.x + scaleAdditive * dir, HitBox.transform.localPosition.y, HitBox.transform.localPosition.z);


        yield return new WaitForSecondsRealtime(.2f);
        
        HitBox.SetActive(true);

        yield return new WaitForSecondsRealtime(.2f);

        HitBox.SetActive(false);

        yield return new WaitForSecondsRealtime(.5f);

        //LOGIC FOR RESETTING ANIMATION
        animator.ResetTrigger(animationTrigger);

        HitBox.transform.localPosition = new Vector3(HitBox.transform.localPosition.x - scaleAdditive * dir, HitBox.transform.localPosition.y, HitBox.transform.localPosition.z);
        HitBox.transform.localScale = new Vector3(HitBox.transform.localScale.x, HitBox.transform.localScale.y - scaleAdditive, HitBox.transform.localScale.z);
    }
}
