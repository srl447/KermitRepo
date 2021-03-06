﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slap : MonoBehaviour
{
    public GameObject HitBox;
    public bool IsSlapping;

    public KeyCode slapKey;

    public Animator animator;
    private Walking _walkingScript;

    public AudioClip slap;

    public TrailRenderer[] trailRenderers;

    private int dir;

    private void Start()
    {
        foreach (TrailRenderer trail in trailRenderers)
        {
            trail.enabled = false;
        }

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
        AudioManager.Instance.audioSource.PlayOneShot(slap, 1.3f);

        foreach (TrailRenderer trail in trailRenderers)
        {
            trail.enabled = true;
        }

        animator.SetTrigger("Slap");

        HitBox.transform.localScale = new Vector3(HitBox.transform.localScale.x, HitBox.transform.localScale.y + .5f, HitBox.transform.localScale.z);
        if (name == "Kermit")
        {
            HitBox.transform.localPosition = new Vector3(HitBox.transform.localPosition.x - .5f * dir, HitBox.transform.localPosition.y, HitBox.transform.localPosition.z);
        }
        else
        {
            HitBox.transform.localPosition = new Vector3(HitBox.transform.localPosition.x + .5f * dir, HitBox.transform.localPosition.y, HitBox.transform.localPosition.z);
        }

        yield return new WaitForSecondsRealtime(.18f);
     
        HitBox.SetActive(true);

        yield return new WaitForSecondsRealtime(.08f);

        HitBox.SetActive(false);

        foreach (TrailRenderer trail in trailRenderers)
        {
            trail.enabled = false;
        }

        yield return new WaitForSecondsRealtime(.66f - .18f - .08f);

        animator.ResetTrigger("Slap");

        if (name == "Kermit")
        {
            HitBox.transform.localPosition = new Vector3(HitBox.transform.localPosition.x + .5f * dir, HitBox.transform.localPosition.y, HitBox.transform.localPosition.z);
        }
        else
        {
            HitBox.transform.localPosition = new Vector3(HitBox.transform.localPosition.x - .5f * dir, HitBox.transform.localPosition.y, HitBox.transform.localPosition.z);
        }
        HitBox.transform.localScale = new Vector3(HitBox.transform.localScale.x, HitBox.transform.localScale.y - .5f, HitBox.transform.localScale.z);



        IsSlapping = false;
    }
}
