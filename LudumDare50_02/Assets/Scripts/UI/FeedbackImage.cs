using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackImage : MonoBehaviour
{
    public Sprite[] feedbackQTEImages;
    Image image;
    InputManager.Inputs nextInput;
    bool needsInput, giveFeedback = true;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public void SwitchImageAndResetTimer(InputManager.Inputs inputs)
    {
        StartCoroutine(LerpAlpha(0, 0.7f, 0.2f));
        image.sprite = feedbackQTEImages[(int)inputs];
        nextInput = inputs;
        needsInput = true;
    }
    public void HighlightIfActiveBeat(InputManager.Inputs inputs)
    {
        if (nextInput == inputs && needsInput)
        {
            HighlightAndVanish();
            needsInput = false;
        }
        else // pressed the wrong button
        {

        }
    }
    void HighlightAndVanish()
    {
        StartCoroutine(HighlightWaitVanish());
    }
    IEnumerator HighlightWaitVanish()
    {
        StartCoroutine(LerpAlpha(0.7f, 1, 0.05f));
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(LerpAlpha(1, 0, 0.3f));
    }
    IEnumerator LerpAlpha(float startAlpha, float endAlpha, float time)
    {
        float timer = time;
        float alpha;
        WaitForEndOfFrame delay = new WaitForEndOfFrame();
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            alpha = Mathf.Lerp(endAlpha, startAlpha, timer / time);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            yield return delay;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, endAlpha);
    }
}
