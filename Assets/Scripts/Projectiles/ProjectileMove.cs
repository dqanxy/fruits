using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed = -10f;
    public float rotation = 0;

    public float initialDelay = 0f;
    public float fireRate = 5f;
    private float countdown;

    private float rotationAmount = 0;
    void Start()
    {
        countdown = fireRate + initialDelay;
    }

    void Update()
    {
        if (countdown <= 0)
        {
            transform.position = transform.position + new Vector3(0, speed, 0) * Time.deltaTime;
            transform.Rotate(new Vector3(0, 0, rotationAmount));
            rotationAmount += rotation;
            if ((speed > 0 && transform.position.y >= 5.2) || (speed < 0 && transform.position.y <= -5.2))
            {
                Destroy(gameObject);
            }

            countdown = fireRate;
        }
        else
        {
            countdown -= 1f;
        }

    }

}
