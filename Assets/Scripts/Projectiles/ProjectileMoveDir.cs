using UnityEngine;

public class ProjectileMoveDir : MonoBehaviour
{
    public float dx;
    public float dy;
    public float multiplier;
    public float rotation = 10;

    private float rotationAmount = 0;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = transform.position + new Vector3(dx, dy, 0) * Time.deltaTime * multiplier;
        transform.Rotate(new Vector3(0, 0, rotationAmount));
        rotationAmount += rotation;
        if(transform.position.y >= 5.2 || transform.position.y <= -5.2 || transform.position.x >= 5.2 || transform.position.x <= -5.2)
        {
            Destroy(gameObject);
        }
    }

}
