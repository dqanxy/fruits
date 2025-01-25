using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;

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
        Vector3 movement = new Vector3(xSpeed, ySpeed, 0);
        transform.position = transform.position + (movement * Time.deltaTime);
    
    }
}
