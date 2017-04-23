using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemeImages : MonoBehaviour {

    public Image[] memeImages;
    int oldCount = -1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.Instance.RoundCount > oldCount)
        {
            memeImages[GameManager.Instance.RoundCount].enabled = !memeImages[GameManager.Instance.RoundCount].enabled;
        }
        oldCount = GameManager.Instance.RoundCount;
	}
}
