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

    public Sprite[] kermitMemes;
    public Sprite[] darkKermitMemes;
    public Image kermitImage;
    public Image darkKermitImage;

    public Animator anim, dAnim;

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
        GlobalPause.Instance.DisableMovement();
        //enable image
        countdownImage.enabled = true;
        kermitImage.enabled = true;
        darkKermitImage.enabled = true;

        anim.SetInteger("State", 0);
        dAnim.SetInteger("State", 0);

        // 3
        countdownImage.sprite = threeSprite;
        kermitImage.sprite = kermitMemes[GameManager.Instance.RoundCount];
        darkKermitImage.sprite = darkKermitMemes[GameManager.Instance.RoundCount];

        countdownImage.transform.localScale = Vector3.zero;
        kermitImage.transform.localScale = Vector3.zero;
        darkKermitImage.transform.localScale = Vector3.zero;
        while (countdownImage.transform.localScale.x < 2.95f)
        {
            kermitImage.transform.localScale = Vector3.Lerp(kermitImage.transform.localScale, Vector3.one * 3f, .2f);
            darkKermitImage.transform.localScale = Vector3.Lerp(darkKermitImage.transform.localScale, Vector3.one * 3f, .2f);
            countdownImage.transform.localScale = Vector3.Lerp(countdownImage.transform.localScale, Vector3.one * 3f, .2f);
            yield return new WaitForEndOfFrame();
        }
        kermitImage.transform.localScale = Vector3.one * 3f;
        darkKermitImage.transform.localScale = Vector3.one * 3f;
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
        kermitImage.enabled = false;
        darkKermitImage.enabled = false;

        GlobalPause.Instance.EnableMovement();
    }

    public IEnumerator NextRoundUI()
    {
        GlobalPause.Instance.DisableMovement();

        // Meme text pops up for one second
        kermitImage.enabled = true;
        darkKermitImage.enabled = true;

        kermitImage.transform.localScale = Vector3.zero;
        darkKermitImage.transform.localScale = Vector3.zero;

        kermitImage.sprite = kermitMemes[GameManager.Instance.RoundCount];
        darkKermitImage.sprite = darkKermitMemes[GameManager.Instance.RoundCount];

        while (kermitImage.transform.localScale.x < 2.95f)
        {
            kermitImage.transform.localScale = Vector3.Lerp(kermitImage.transform.localScale, Vector3.one * 3f, .2f);
            darkKermitImage.transform.localScale = Vector3.Lerp(darkKermitImage.transform.localScale, Vector3.one * 3f, .2f);
            yield return new WaitForEndOfFrame();
        }

        kermitImage.transform.localScale = Vector3.one * 3f;
        darkKermitImage.transform.localScale = Vector3.one * 3f;

        yield return new WaitForSecondsRealtime(2f);


        // Slap pops in
        countdownImage.enabled = true;
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


        // FIGHT
        kermitImage.enabled = false;
        darkKermitImage.enabled = false;
        countdownImage.enabled = false;
        GlobalPause.Instance.EnableMovement();

    }
}
