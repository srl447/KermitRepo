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

    private Animator _animator;
    private Walking _walkingScript;

    private int dir;

    private void Start()
    {
        _animator = GetComponent<Animator>();
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
                    StartCoroutine(SlapAction(0, 0f));
                }
            }
	        else
	        {
                // Far Slap
                if (_cooldownFrameCountdown == 0)
                {
                    StartCoroutine(SlapAction(2, .5f));
                }
            }
            _keyHoldCount = 0;
	    }
	}

    IEnumerator SlapAction(int indexOfAnimationToPlay, float scaleAdditive)
    {

        _prepFrameCountdown = 4;
        _attackFrameCountdown = 4;
        _cooldownFrameCountdown = 8;

        //LOGIC FOR TRIGGERING ANIMATION
        //_animator.SetTrigger("Slap");
        
        //LOGIC FOR RESETTING ANIMATION
        //_animator.ResetTrigger("Slap");

        HitBox.transform.localScale = new Vector3(HitBox.transform.localScale.x, HitBox.transform.localScale.y + scaleAdditive, HitBox.transform.localScale.z);
        HitBox.transform.localPosition = new Vector3(HitBox.transform.localPosition.x + scaleAdditive * dir, HitBox.transform.localPosition.y, HitBox.transform.localPosition.z);

        while (_prepFrameCountdown > 0 )
        {
            --_prepFrameCountdown;
            yield return new WaitForEndOfFrame();
        }
        
        HitBox.SetActive(true);
        //GetComponent<Collider>().enabled = false;
        while (_attackFrameCountdown > 0)
        {
            --_attackFrameCountdown;
            yield return new WaitForEndOfFrame();
        }
        HitBox.SetActive(false);
        //GetComponent<Collider>().enabled = true;

        while (_cooldownFrameCountdown > 0)
        {
            --_cooldownFrameCountdown;
            yield return new WaitForEndOfFrame();
        }

        HitBox.transform.localPosition = new Vector3(HitBox.transform.localPosition.x - scaleAdditive * dir, HitBox.transform.localPosition.y, HitBox.transform.localPosition.z);
        HitBox.transform.localScale = new Vector3(HitBox.transform.localScale.x, HitBox.transform.localScale.y - scaleAdditive, HitBox.transform.localScale.z);
    }
}
