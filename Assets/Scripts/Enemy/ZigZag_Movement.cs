using UnityEngine;

public class ZigZag_Movement : MonoBehaviour
{
    // The speed at which the player will move when going left and right
    public float speedX;

    // The speed at which the player will move when going up and down
    public float speedY;

    //the amount of time in between each rotation
    public float timeToSwitchX;
    public float timeToSwitchY;

    //the amount of time before deletion
    public float destroyTime;

    // A reference to a Rigidbody2D component that's on our character
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D that's on our character
        body = GetComponent<Rigidbody2D>();
        InvokeRepeating("switchX", timeToSwitchX, timeToSwitchX);
        InvokeRepeating("switchY", timeToSwitchY, timeToSwitchY);

        Destroy(gameObject, destroyTime);
    }

    public void switchX()
    {
        speedX = speedX * -1;
    }

    public void switchY()
    {
        speedY = speedY * -1;
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime is the time between this frame and the last frame
        // We use this whenever moving because we want to keep the speed constant
        // Even if our frame rate drops
        Vector2 delta = new Vector2(speedX * Time.deltaTime, speedY * Time.deltaTime);

        transform.Translate(-delta);
    }

}
