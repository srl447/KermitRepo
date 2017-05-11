using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DetectSlap : MonoBehaviour
{
    public int winCount = 0;

    public UI_Rounds ui_roundsScript;
    public Image winImage;
    public Image KOImage;
    public Vector3 startPos;
    public Vector3 startRot;
    Vector3 cameraStartPos;
    Vector3 cameraStartRot;
    bool finalRotate;
    private bool shake;
    public DetectSlap otherPlayer;
    int timer;

    public IntroCountDown introCountDownScript;

    public AudioSource soundManager;
    public AudioClip win;
    public AudioClip KO;
    public AudioClip victoryTheme;
    public GameObject slapEffect;
    public GameObject UI;

    public GameObject winPose;


    private Animator _animator;

    public void Awake()
    {
        startPos = transform.position;
        startRot = transform.eulerAngles;
        cameraStartPos = Camera.main.transform.position;
        cameraStartRot = Camera.main.transform.eulerAngles;
        otherPlayer = GameObject.FindGameObjectWithTag(tag == "kermit" ? "darkKermit" : "kermit").GetComponent<DetectSlap>();
        _animator = transform.GetChild(1).GetComponent<Animator>();
        UI.SetActive(true);
        winPose.SetActive(false);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "slap") //Now this just starts my script and freezes time
        {
            GlobalPause.Instance.DisableMovement();
            // Shows Slap POW Effect
            GameObject effectObject = GameObject.Instantiate(slapEffect);
            effectObject.transform.position = new Vector3(col.contacts[0].point.x, col.contacts[0].point.y + 1f, col.contacts[0].point.z);
            //
            AudioManager.Instance.PlayOneShot(win);
            winCount++;
            Time.timeScale = .1f;
            if (winCount < 3)
            {
                _animator.SetTrigger("React");
                StartCoroutine(CameraRotate(.01f));
            }
            else  if (winCount == 3)
            {
                _animator.SetTrigger("React");
                StartCoroutine(GameEnd());
            }
        }
    }

    IEnumerator CameraRotate(float waitTime) //initiates the rotating camera process
    {
        //moves the camera to the position needed to rotate
        if (transform.position.x < otherPlayer.transform.position.x)
        {
            Camera.main.transform.position = new Vector3(((transform.position.x + otherPlayer.transform.position.x) / 2) + 3, cameraStartPos.y - 3, cameraStartPos.z + 11.4f);
            Camera.main.transform.eulerAngles = new Vector3(20f, -45f, 0f);
        }
        if (transform.position.x > otherPlayer.transform.position.x)
        {
            Camera.main.transform.position = new Vector3(((transform.position.x + otherPlayer.transform.position.x) / 2) - 3, cameraStartPos.y - 3, cameraStartPos.z + 11.4f);
            Camera.main.transform.eulerAngles = new Vector3(20f, 45f, 0f);
        }
        //changes the variable so code can run in update
        //rotateCamera = true;
        //ScreenShake.shakeStrength = 10f;
        for (int i = 0; i < 90; i++)
        {
            if (transform.position.x > otherPlayer.transform.position.x)
            {
                Camera.main.transform.eulerAngles += new Vector3(0f, -1f, 0f);
                Camera.main.transform.position += new Vector3(.05f, 0f, 0f);
            }
            if (transform.position.x < otherPlayer.transform.position.x)
            {
                Camera.main.transform.eulerAngles += new Vector3(0f, 1f, 0f);
                Camera.main.transform.position += new Vector3(-.05f, 0f, 0f);
            }
            yield return new WaitForSecondsRealtime(waitTime);
        }
        resetWorld();
    }

    void resetWorld() //moved Matt's code here so I could execute it after rotation
    {
        //Color colorToChangeTo = tag == "kermit" ? ui_roundsScript.darkKermitWon : ui_roundsScript.kermitWon;

        Time.timeScale = 1;

        //rotateCamera = false;

        /*if (winCount >= 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }*/

        //ui_roundsScript.ChangeLight(GameManager.Instance.RoundCount, colorToChangeTo);
        GameManager.Instance.RoundCount++;

        _animator.ResetTrigger("React");
        otherPlayer.GetComponent<DetectSlap>()._animator.ResetTrigger("React");

        transform.position = startPos;
        transform.eulerAngles = startRot;
        Camera.main.transform.position = cameraStartPos;
        Camera.main.transform.eulerAngles = cameraStartRot;
        otherPlayer.transform.position = otherPlayer.startPos;
        otherPlayer.transform.eulerAngles = otherPlayer.startRot;
        GlobalPause.Instance.EnableMovement();
        StartCoroutine(introCountDownScript.Countdown());

    }

    IEnumerator GameEnd() //Displays Win Text
    {
        Time.timeScale = 0f;
        AudioManager.Instance.PlayOneShot(KO); //KO Sound
        for (int i = 0; i < 20; i++) //KO Coming in Script
        {
            KOImage.fillAmount += .009f*i;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(1f); //Wait to allow recognition of KO
        KOImage.enabled = !KOImage.enabled; //Turn off KO
        winImage.enabled = !winImage.enabled; //Turn on Results
        AudioManager.Instance.PlayOneShot(victoryTheme);
        Camera.main.transform.position = new Vector3(.85f, -13.57f, -75.31f);
        Camera.main.transform.eulerAngles = new Vector3(12.77f, -19.026f, 2.565f);
        UI.SetActive(false);
        winPose.SetActive(true);
        GlobalPause.Instance.EnableMovement();
        //finalRotate = true;
        //rotatePoint = new Vector3(((transform.position.x + otherPlayer.transform.position.x) / 2), ((transform.position.y + otherPlayer.transform.position.y) / 2), ((transform.position.z + otherPlayer.transform.position.z) / 2));
    }

    void Update()
    {
        Camera.main.transform.position = new Vector3(((transform.position.x + otherPlayer.transform.position.x) / 2), Camera.main.transform.position.y, Camera.main.transform.position.z);
    }
}
