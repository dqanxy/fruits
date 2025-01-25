using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    float speed = 20f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = transform.position + new Vector3(0, speed, 0) * Time.deltaTime;
        if(transform.position.y >= 5.2)
        {
            Destroy(gameObject);
        }
    }

}
