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

    public Walking kermitWalk;
    public Walking darkKermitWalk;
    public Slap kermitSlap;
    public Slap darkKermitSlap;
    public Jump kermitJump;
    public Jump darkKermitJump;
    public Block kermitBlock;
    public DarkBlock darkKermitBlock;

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
        kermitBlock.enabled = false;
        kermitJump.enabled = false;
        kermitSlap.enabled = false;
        kermitWalk.enabled = false;
        darkKermitBlock.enabled = false;
        darkKermitJump.enabled = false;
        darkKermitSlap.enabled = false;
        darkKermitWalk.enabled = false;
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
        countdownImage.sprite = fightSprite;
        countdownImage.preserveAspect = true;
        countdownImage.transform.localScale = Vector3.zero;
        while (countdownImage.transform.localScale.x < 4.95f)
        {
            countdownImage.transform.localScale = Vector3.Lerp(countdownImage.transform.localScale, Vector3.one * 5f, .2f);
            yield return new WaitForEndOfFrame();
        }
        countdownImage.transform.localScale = Vector3.one * 5f;
        yield return new WaitForSecondsRealtime(.5f);

        // Turn off the Countdown Image
        countdownImage.enabled = false;

        kermitBlock.enabled = true;
        kermitJump.enabled = true;
        kermitSlap.enabled = true;
        kermitWalk.enabled = true;
        darkKermitBlock.enabled = true;
        darkKermitJump.enabled = true;
        darkKermitSlap.enabled = true;
        darkKermitWalk.enabled = true;
    }
}
