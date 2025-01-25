using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FlashManager : MonoBehaviour
{

    Coroutine flashCoro;
    public Image w;
    public Image b;

    public static FlashManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(instance);
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetAlpha(Image im, float a)
    {
        im.color = new Color(im.color.r, im.color.g, im.color.b, a);
    }

    IEnumerator ChangeAlphaOverTime(Image im, float begin, float end, float time)
    {
        float timer = 0;
        
        while(timer < time)
        {
            timer += Time.deltaTime;
            SetAlpha(im, Mathf.Lerp(begin, end, timer / time));
            yield return null;

        }

        im.color = new Color(im.color.r, im.color.g, im.color.b, end);

    }

    public static void WhiteOverTime(float begin, float end, float time)
    {
        instance._WhiteOverTime(begin, end, time);
    }

    public static void BlackOverTime(float begin, float end, float time)
    {
        instance._BlackOverTime(begin, end, time);
    }

    public void _WhiteOverTime(float begin, float end, float time)
    {
        if (flashCoro != null)
        {
            StopCoroutine(flashCoro);
        }
        SetAlpha(w, begin);
        SetAlpha(b, 0);
        flashCoro = StartCoroutine(ChangeAlphaOverTime(w, begin, end, time));
    }

    public void _BlackOverTime(float begin, float end, float time)
    {
        if (flashCoro != null)
        {
            StopCoroutine(flashCoro);
        }
        SetAlpha(b, begin);
        SetAlpha(w, 0);
        flashCoro = StartCoroutine(ChangeAlphaOverTime(b, begin, end, time));
    }
}
