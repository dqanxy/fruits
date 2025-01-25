using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TempFadeInOut : MonoBehaviour
{

    float timer = 0f;
    float fadeTime = 1f;
    TextMeshProUGUI tmpro;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeInOut());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FadeInOut()
    {
        tmpro = GetComponent<TextMeshProUGUI>();
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(ChangeAlphaOverTime(0, 1, fadeTime));
        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(ChangeAlphaOverTime(1,0, fadeTime));
    }


    IEnumerator ChangeAlphaOverTime(float begin, float end, float time)
    {
        float timer = 0;

        while (timer < time)
        {
            timer += Time.deltaTime;
            SetAlpha(Mathf.Lerp(begin, end, timer / time));
            yield return null;

        }

        SetAlpha(end);

    }
    public void SetAlpha(float a)
    {
        tmpro.color = new Color(tmpro.color.r, tmpro.color.g, tmpro.color.b, a);
    }
}
