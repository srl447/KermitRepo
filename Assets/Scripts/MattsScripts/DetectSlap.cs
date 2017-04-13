using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectSlap : MonoBehaviour
{

    public UI_Rounds ui_roundsScript;

    public Vector3 startPos;
    public Vector3 startRot;
    Vector3 cameraStartPos;
    Vector3 cameraStartRot;
    bool rotateCamera;
    public DetectSlap otherPlayer;
    int timer;

    public void Awake()
    {
        startPos = transform.position;
        startRot = transform.eulerAngles;
        cameraStartPos = Camera.main.transform.position;
        cameraStartRot = Camera.main.transform.eulerAngles;
        otherPlayer = GameObject.FindGameObjectWithTag(tag == "kermit" ? "darkKermit" : "kermit").GetComponent<DetectSlap>();
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "slap") //Now this just starts my script and freezes time
        {
            Time.timeScale = 0;
            CameraRotate();
        }
    }

    void CameraRotate() //initiates the rotating camera process
    { 
        //moves the camera to the position needed to rotate
        Camera.main.transform.position = new Vector3(((transform.position.x + otherPlayer.transform.position.x) / 2) - 3, (transform.position.x + otherPlayer.transform.position.x) / 3, cameraStartPos.z + 3);
        Camera.main.transform.eulerAngles = new Vector3(11f, 45f, 0f);
        //changes the variable so code can run in update
        rotateCamera = true;
    }

    void resetWorld() //moved Matt's code here so I could execute it after rotation
    {
        Color colorToChangeTo = tag == "kermit" ? ui_roundsScript.darkKermitWon : ui_roundsScript.kermitWon;

        ui_roundsScript.ChangeLight(GameManager.Instance.RoundCount, colorToChangeTo);

        //resetting my variables and timescale
        Time.timeScale = 1;
        timer = 0;
        rotateCamera = false;

        if (GameManager.Instance.RoundCount >= 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }
        GameManager.Instance.RoundCount++;

        transform.position = startPos;
        transform.eulerAngles = startRot;
        Camera.main.transform.position = cameraStartPos;
        Camera.main.transform.eulerAngles = cameraStartRot;
        otherPlayer.transform.position = otherPlayer.startPos;
        otherPlayer.transform.eulerAngles = otherPlayer.startRot;
    }
    void Update()
    {
        if (rotateCamera) //rotates the camera
        {
            Camera.main.transform.eulerAngles += new Vector3(0f, -1f, 0f);
            Camera.main.transform.position += new Vector3(.1f, 0f, 0f);
            timer += 1;
        }
        if(timer >= 90) //runs Matt's scripts when camera rotation done
        {
            resetWorld();
        }

    }
}
