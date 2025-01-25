using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject projectile;

    private float cooldown = 0; 
    void Start()
    {
    }

    void Update()
    {
        float xSpeed = 0;
        float ySpeed = 0;

        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            xSpeed = -speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            xSpeed = speed;
        }

        if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            ySpeed = speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            ySpeed = -speed;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if(cooldown < Time.time)
            {
                GameObject newProjectile = Instantiate(projectile);
                newProjectile.transform.position = transform.position + new Vector3(Random.Range(-.3f, .3f), Random.Range(-.3f, .3f));
                cooldown = Time.time + 10.0f/60;
            }

        }

        Vector3 movement = new Vector3(xSpeed, ySpeed, 0);
        transform.position = transform.position + (movement * Time.deltaTime);

        if (transform.position.x < -3.4f)
        {
            transform.position = new Vector3(-3.4f, transform.position.y);
        }

        if (transform.position.x > 3.4f)
        {
            transform.position = new Vector3(3.4f, transform.position.y);
        }

        if (transform.position.y < -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f);
        }

        if (transform.position.y > 4.5f)
        {
            transform.position = new Vector3(transform.position.x, 4.5f);
        }

    }
}
