using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public GameObject cube; //visual for testing
    public Slap slap1;
    public GameObject arm1, arm2; // need arms to change tags later

	public Animator kermitAnim;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && !slap1.IsSlapping) //checking for block button
        {
            StartCoroutine(blockStartup(.08f)); //starting block sequence
        }
    }

    IEnumerator blockStartup(float startup) //block startup
    {
        slap1.enabled = !slap1.enabled; //disables slap command
        yield return new WaitForSeconds(startup); //waits to start blocking
		kermitAnim.SetTrigger("Block");
        cube.SetActive(true);
        StartCoroutine(blockDuration(.2f)); //starts duration of blocking
    }

    IEnumerator blockDuration(float duration) //block duration
    {
        gameObject.layer = 10;
        MoveToLayer(gameObject.transform, 10); //activates function to put children in layer
        yield return new WaitForSeconds(duration); //block lasts for this time
        StartCoroutine(blockEndLag(.12f)); // starts endlag
    }

    IEnumerator blockEndLag(float endLag) //block end lag
    {
        cube.SetActive(false);
        arm1.tag = "slap"; //sets arms back to slap so they can work again
        arm2.tag = "slap";
        gameObject.layer = 8;
        MoveToLayer(gameObject.transform, 8);
        yield return new WaitForSeconds(endLag); //waits for the endlag
		kermitAnim.ResetTrigger("Block");
        slap1.enabled = !slap1.enabled; //re-enables slapping
    }

    void MoveToLayer(Transform root, int layer) // to change the layer of all the children in kermit
    {
        root.gameObject.layer = layer;
        foreach (Transform child in root)
        MoveToLayer(child, layer);
    }
}