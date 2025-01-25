using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCutscene : MonoBehaviour
{
    public string nextScene;
    public TextMeshProUGUI text;
    float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("SkipCutscene") || Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(nextScene);
        }

        timer += Time.deltaTime;

        if (text == null) return;

        if( timer < .5f)
        {

        }
        else if(timer < 1.5f)
        {
            text.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, (timer - .5f) / 1f));
        }
        else if (timer < 3f)
        {
            text.color = new Color(1, 1, 1, 1);
        }
        else if (timer < 4f)
        {
            text.color = new Color(1, 1, 1, Mathf.Lerp(1, 0, (timer - 3f) / 1.5f));
        }
        else
        {

            text.color = new Color(1, 1, 1, 0);
        }
    }
}
