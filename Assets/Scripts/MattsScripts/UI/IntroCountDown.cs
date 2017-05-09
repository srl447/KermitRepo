using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCountDown : MonoBehaviour
{
    public Sprite threeSprite;
    public Sprite twoSprite;
    public Sprite oneSprite;
    public Sprite fightSprite;

    public Image countdownImage;

    public void Awake()
    {
        countdownImage = GetComponent<Image>();
    }

    public void Start()
    {
        StartCoroutine(Countdown());
    }

    public IEnumerator Countdown()
    {
        //enable image
        countdownImage.enabled = true;

        // 3
        countdownImage.sprite = threeSprite;
        countdownImage.transform.localScale = Vector3.zero;
        while (countdownImage.transform.localScale.x < 2.95f)
        {
            countdownImage.transform.localScale = Vector3.Lerp(countdownImage.transform.localScale, Vector3.one * 3f, .2f);
            yield return new WaitForEndOfFrame();
        }
        countdownImage.transform.localScale = Vector3.one * 3f;
        yield return new WaitForSecondsRealtime(.6f);


        // 2
        countdownImage.sprite = twoSprite;
        countdownImage.transform.localScale = Vector3.zero;
        while (countdownImage.transform.localScale.x < 2.95f)
        {
            countdownImage.transform.localScale = Vector3.Lerp(countdownImage.transform.localScale, Vector3.one * 3f, .2f);
            yield return new WaitForEndOfFrame();
        }
        countdownImage.transform.localScale = Vector3.one * 3f;
        yield return new WaitForSecondsRealtime(.6f);

        // 1
        countdownImage.sprite = oneSprite;
        countdownImage.transform.localScale = Vector3.zero;
        while (countdownImage.transform.localScale.x < 2.95f)
        {
            countdownImage.transform.localScale = Vector3.Lerp(countdownImage.transform.localScale, Vector3.one * 3f, .2f);
            yield return new WaitForEndOfFrame();
        }
        countdownImage.transform.localScale = Vector3.one * 3f;
        yield return new WaitForSecondsRealtime(.6f);

        // FIGHT
        //countdownImage.sprite = fightSprite;
        //countdownImage.transform.localScale = Vector3.zero;
        //while (countdownImage.transform.localScale.x < .95)
        //{
        //    countdownImage.transform.localScale = Vector3.Lerp(countdownImage.transform.localScale, Vector3.one, .2f);
        //    yield return new WaitForEndOfFrame();
        //}
        //countdownImage.transform.localScale = Vector3.one;
        //yield return new WaitForSecondsRealtime(.5f);

        // Turn off the Countdown Image
        countdownImage.enabled = false;
    }
}
