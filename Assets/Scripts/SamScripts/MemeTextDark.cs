using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemeTextDark : MonoBehaviour
{

    string text1, text2, text3, text4, text5; //creates strings for all the text
    string[] allMemeText; //creates an array to store the text in
    int round = GameManager.Instance.RoundCount; //sets round to the global roundcount 
    Text memeText; //The text to edit
                   // Use this for initialization
    void Start()
    {
        //Sets all the strings to the meme text
        text1 = "Stare at your phone in bed for an hour";
        text2 = "Now spend it all";
        text3 = "Go buy an entire pizza you earned it";
        text4 = "OVERREACT";
        text5 = "Stay up till 4am";


        memeText = GetComponent<Text>(); //assigns the text component to the text thingy
        allMemeText = new string[] { text1, text2, text3, text4, text5 }; //puts all the strings into the array
    }

    // Update is called once per frame
    void Update()
    {
        memeText.text = allMemeText[round]; //changes the text to match the meme text corresponding with the current round
    }
}
