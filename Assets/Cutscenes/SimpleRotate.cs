using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Vector3 velo;
    public bool stutter = false;

    float timer = .1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stutter)
        {
            transform.Rotate(Time.deltaTime * velo);
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > .07f)
            {
                transform.Rotate(timer * velo);
                timer = 0f;
            }

        }
    }
}
