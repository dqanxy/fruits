using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{

    Coroutine textCoro;
    public TextMeshProUGUI tmpro;

    public static TextManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
        tmpro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void TextWithDelay(string newText)
    {
        instance._TextWithDelay(newText);
    }

    public void _TextWithDelay(string newText)
    {
        if (textCoro != null)
        {
            StopCoroutine(textCoro);
        }
        textCoro = StartCoroutine(DelayedText(newText));
    }

    IEnumerator DelayedText(string newText)
    {
        tmpro.text = "";
        yield return new WaitForSeconds(.5f);
        tmpro.text = newText;
    }
}
