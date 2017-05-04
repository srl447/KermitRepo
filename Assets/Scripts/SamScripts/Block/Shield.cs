using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    public GameObject arm1, arm2, player; //arms to change tag from slap to disable them
    public Walking walk;
    public AudioClip blockSound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(gameObject.layer == 10)
        {
            gameObject.layer = 11; // making this object a shield 
            arm1.tag = "notSlap"; //changing tags of arms
            arm2.tag = "notSlap";
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == arm2 && walk.flipped)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-10000f, 0f, 0f)); //applies force to shield backwards when hit
            player.GetComponent<Rigidbody>().AddForce(new Vector3(-10000f, 0f, 0f)); //same but for player
            AudioManager.Instance.audioSource.PlayOneShot(blockSound, 2f);
        }
        else if (collision.gameObject == arm2 && !walk.flipped)
        {
            AudioManager.Instance.audioSource.PlayOneShot(blockSound, 2f);
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(10000f, 0f, 0f)); //applies force to shield backwards when hit
            player.GetComponent<Rigidbody>().AddForce(new Vector3(10000f, 0f, 0f)); //same but for player
        }
    }
}
