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
	    if (Input.GetKeyDown(slapKey) && !IsSlapping)
	    {
	        StartCoroutine(SlapAction());
	    }
	}

    IEnumerator SlapAction()
    {
        IsSlapping = true;
        //LOGIC FOR TRIGGERING ANIMATION
        
        animator.SetTrigger("Slap");

        HitBox.transform.localScale = new Vector3(HitBox.transform.localScale.x, HitBox.transform.localScale.y + .75f, HitBox.transform.localScale.z);
        HitBox.transform.localPosition = new Vector3(HitBox.transform.localPosition.x + .75f * dir, HitBox.transform.localPosition.y, HitBox.transform.localPosition.z);

        yield return new WaitForSecondsRealtime(.16f);
        
        HitBox.SetActive(true);

        yield return new WaitForSecondsRealtime(.1f);

        HitBox.SetActive(false);

        //LOGIC FOR RESETTING ANIMATION
        animator.ResetTrigger("Slap");

        HitBox.transform.localPosition = new Vector3(HitBox.transform.localPosition.x - .75f * dir, HitBox.transform.localPosition.y, HitBox.transform.localPosition.z);
        HitBox.transform.localScale = new Vector3(HitBox.transform.localScale.x, HitBox.transform.localScale.y - .75f, HitBox.transform.localScale.z);

        IsSlapping = false;
    }
}
