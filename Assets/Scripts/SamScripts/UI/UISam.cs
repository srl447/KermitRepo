using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISam : MonoBehaviour {

    public Image[] kermitTicks;
    public Image[] darkTicks;
    public DetectSlap kermitWinCount;
    public DetectSlap darkWinCount;
    int oldCount;
    int darkOld;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (kermitWinCount.winCount > oldCount)
        {
            kermitTicks[kermitWinCount.winCount - 1].enabled = !kermitTicks[kermitWinCount.winCount].enabled;
        }
        oldCount = kermitWinCount.winCount;
        if (darkWinCount.winCount > darkOld)
        {
            darkTicks[darkWinCount.winCount - 1].enabled = !darkTicks[darkWinCount.winCount].enabled;
        }
        darkOld = darkWinCount.winCount;
    }

}
