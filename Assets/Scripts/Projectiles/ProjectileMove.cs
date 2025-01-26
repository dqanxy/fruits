using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed = -10f;
    public float rotation = 0;

    public float initialDelay = 0f;

    private float rotationAmount = 0;
    void Start()
    {
        
    }

    void Update()
    {
        if (initialDelay > 0)
        {
            --initialDelay;
        }
        
        
        else
        {
            transform.position = transform.position + new Vector3(0, speed, 0) * Time.deltaTime;
            transform.Rotate(new Vector3(0, 0, rotationAmount));
            rotationAmount += rotation;
            if ((speed > 0 && transform.position.y >= 5.2) || (speed < 0 && transform.position.y <= -5.2))
            {
                Destroy(gameObject);
            }

        }

      
    }

}
