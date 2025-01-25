using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeToWhiteOnEnd : MonoBehaviour
{
    Image img;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToWhite()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        float timer = 1f;

        while(timer > 0f)
        {
            yield return null;
            timer -= Time.deltaTime;
        }


        timer = 5f;


        while (timer > 0f)
        {
            yield return null;
            timer -= Time.deltaTime;

            img.color = Color.Lerp(new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), timer / 5f);
        }

        img.color = new Color(1, 1, 1, 1);

        timer = 1f;

        while (timer > 0f)
        {
            yield return null;
            timer -= Time.deltaTime;
        }

        SceneManager.LoadScene("PodiumScene");
    }
}
