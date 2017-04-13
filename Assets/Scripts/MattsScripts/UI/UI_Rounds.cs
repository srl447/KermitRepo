using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Rounds : MonoBehaviour
{
    public Image[] roundLights;

    public Color deactivated;
    public Color kermitWon;
    public Color darkKermitWon;

    

    void Start () {
        foreach (Image light in roundLights)
        {
            light.color = deactivated;
        }
	}

    public void ChangeLight(int lightIndexToChange, Color colorToChangeTo)
    {
        roundLights[lightIndexToChange].color = colorToChangeTo;
    }
    
}
