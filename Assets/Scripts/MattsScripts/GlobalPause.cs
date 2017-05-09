using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns;

public class GlobalPause : Singleton<GlobalPause>
{
    public Walking kermitWalk;
    public Walking darkKermitWalk;
    public Slap kermitSlap;
    public Slap darkKermitSlap;
    public Jump kermitJump;
    public Jump darkKermitJump;
    public Block kermitBlock;
    public DarkBlock darkKermitBlock;

    void Start () {
		
	}
	
	void Update () {
		
	}

    public void DisableMovement()
    {
        kermitBlock.enabled = false;
        kermitJump.enabled = false;
        kermitSlap.enabled = false;
        kermitWalk.enabled = false;
        darkKermitBlock.enabled = false;
        darkKermitJump.enabled = false;
        darkKermitSlap.enabled = false;
        darkKermitWalk.enabled = false;
    }

    public void EnableMovement()
    {
        kermitBlock.enabled = true;
        kermitJump.enabled = true;
        kermitSlap.enabled = true;
        kermitWalk.enabled = true;
        darkKermitBlock.enabled = true;
        darkKermitJump.enabled = true;
        darkKermitSlap.enabled = true;
        darkKermitWalk.enabled = true;
    }
}
