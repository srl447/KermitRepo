using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemeText : MonoBehaviour
{
    string text1, text2, text3, text4, text5; //creates strings for all the text
    string[] allMemeText; //creates an array to store the text in
    Text memeText; //The text to edit
	// Use this for initialization
	void Start ()
    {
        //Sets all the strings to the meme text
        text1 = "Well I just woke up. Time to be productive";
        text2 = "I'm so happy that I'm saving money";
        text3 = "I just finished a workout, time to eat something healthy";
        text4 = "I'm sure there's a logical explanation to this";
        text5 = "I should really go to bed";


        memeText = GetComponent<Text>(); //assigns the text component to the text thingy
        allMemeText = new string[] { text1, text2, text3, text4, text5 }; //puts all the strings into the array
    }
	
	// Update is called once per frame
	void Update ()
    {
        memeText.text = allMemeText[GameManager.Instance.RoundCount]; //changes the text to match the meme text corresponding with the current round
	}
}
