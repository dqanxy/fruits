using UnityEngine;

public class ScaleUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Vector3 initScale;
    public bool scale = false;
    float timer = 0f;
    void Start()
    {
        initScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (scale)
        {
            timer += Time.deltaTime;
            if (timer < .5f)
            {
                transform.localScale = initScale * (timer / .5f);
            }
            else
            {
                transform.localScale = initScale;
            }
        }
    }
}
