using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectSlap : MonoBehaviour
{

    public UI_Rounds ui_roundsScript;

    public Vector3 startPos;
    public Vector3 startRot;

    public DetectSlap otherPlayer;

    public void Awake()
    {
        startPos = transform.position;
        startRot = transform.eulerAngles;

        otherPlayer = GameObject.FindGameObjectWithTag(tag == "kermit" ? "darkKermit" : "kermit").GetComponent<DetectSlap>();
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "slap")
        {
            Color colorToChangeTo = name == "kermit" ? ui_roundsScript.darkKermitWon : ui_roundsScript.kermitWon;

            ui_roundsScript.ChangeLight(GameManager.Instance.RoundCount, colorToChangeTo);

            if (GameManager.Instance.RoundCount >= 4)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                return;
            }
            GameManager.Instance.RoundCount++;

            transform.position = startPos;
            transform.eulerAngles = startRot;
            otherPlayer.transform.position = otherPlayer.startPos;
            otherPlayer.transform.eulerAngles = otherPlayer.startRot;
        }
    }
}
