using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed = 20f;
    public float rotation = 0;

    private float rotationAmount = 0;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = transform.position + new Vector3(0, speed, 0) * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, rotationAmount));
        rotationAmount += rotation;
        if((speed > 0 && transform.position.y >= 5.2) || (speed < 0 && transform.position.y <= -5.2))
        {
            Destroy(gameObject);
        }
    }

}
