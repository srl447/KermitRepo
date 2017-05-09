using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    Light light1;
    public Image enter;
    public AudioClip bang;
    AudioSource audio1;
    void Start()
    {
        light1 = GetComponent<Light>();
        audio1 = GetComponent<AudioSource>();
    }
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            StartCoroutine(flashStart());
            enter.enabled = !enter.enabled;
        }
	}

    IEnumerator flashStart()
    {
        yield return new WaitForSeconds(.1f);
        light1.intensity = 4;
        audio1.PlayOneShot(bang);
        yield return new WaitForSeconds(.1f);
        light1.intensity = 1;
        yield return new WaitForSeconds(.1f);
        light1.intensity = 4;
        audio1.PlayOneShot(bang);
        yield return new WaitForSeconds(.1f);
        light1.intensity = 1;
        yield return new WaitForSeconds(.2f);
        SceneManager.LoadScene(1);
    }
}
