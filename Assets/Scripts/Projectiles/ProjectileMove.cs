using System.Runtime.CompilerServices;
using UnityEngine;
using Unity.Mathematics;

public class ProjectileMove : MonoBehaviour
{
    public float speed = -10f;
    public float directionDegrees = 0;
    public float inPlaceRevolutionRate = 0;

    private float rotationAmount = 0;
    void Start()
    {
        directionDegrees = Mathf.Deg2Rad * directionDegrees;  
    }

    void Update()
    {


        transform.position = transform.position + new Vector3(speed * math.sin(directionDegrees), speed * math.cos(directionDegrees), 0) * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, rotationAmount));
        rotationAmount = inPlaceRevolutionRate;
        if ((speed > 0 && transform.position.y >= 5.2) || (speed < 0 && transform.position.y <= -5.2))
        {
            Destroy(gameObject);
        }

        

      
    }

}
