using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleImage : MonoBehaviour
{
    RectTransform transform;
    Image image;
    bool beatWasHit;

    private void Awake()
    {
        transform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    public void BeatWasHit()
    {
        beatWasHit = true;
    }
    public void HitOnBeat(float timeTilHit)
    {
        beatWasHit = false;
        StartCoroutine(ScaleCircle(timeTilHit));
        StartCoroutine(LerpAlpha(0,1,0.2f));
    }
    IEnumerator ScaleCircle(float timeTilHit)
    {
        Vector3 startScale = new Vector3(1,1,1);
        transform.localScale = startScale;
        float timer = timeTilHit;
        WaitForEndOfFrame delay = new WaitForEndOfFrame();
        while (!beatWasHit)
        {
            timer -= Time.deltaTime;
            transform.localScale = Vector3.Lerp(Vector3.zero, startScale, timer / timeTilHit);
            beatWasHit = timer <= 0;
            yield return delay;
        }
        transform.localScale = Vector3.zero;
        StartCoroutine(LerpAlpha(1, 0, 0.1f));
    }
    IEnumerator LerpAlpha(float startAlpha, float endAlpha, float time)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, startAlpha);
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
