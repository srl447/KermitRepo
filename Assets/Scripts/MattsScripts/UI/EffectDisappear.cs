using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDisappear : MonoBehaviour
{
	void Start ()
	{
	    StartCoroutine(DelayedDestroy(1.3f));
	}

    private IEnumerator DelayedDestroy(float delayAmount)
    {
        yield return new WaitForSecondsRealtime(delayAmount);
        Destroy(gameObject);
    }
}
