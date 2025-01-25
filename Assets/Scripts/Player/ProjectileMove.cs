using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed = 20f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = transform.position + new Vector3(0, speed, 0) * Time.deltaTime;
        if((speed > 0 && transform.position.y >= 5.2) || (speed < 0 && transform.position.y <= -5.2))
        {
            Destroy(gameObject);
        }
    }

}
