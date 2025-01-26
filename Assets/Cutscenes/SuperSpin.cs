using UnityEngine;

public class SuperSpin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool begin = false;

    float velo = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (begin)
        {
            velo *= 1.008f;
            transform.Rotate(new Vector3(0, velo, 0));
        }

    }
}
