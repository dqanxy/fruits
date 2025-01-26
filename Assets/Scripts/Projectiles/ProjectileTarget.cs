using System.Runtime.CompilerServices;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.UIElements;

public class ProjectileTarget : MonoBehaviour
{
    public float speed = 10f;

    private float deltaX = 0f;
    private float deltaY = -10f;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {

            float theta = Mathf.Atan((transform.position.y-player.transform.position.y) / (transform.position.x-player.transform.position.x));
            deltaX = speed * Mathf.Cos(theta);
            deltaY = speed * Mathf.Sin(theta);

            if(deltaY > 0)
            {
                deltaY = -deltaY;
                deltaX = -deltaX;
            }
        }
    }

    void Update()
    {
        if (transform.position.y >= 5.2 || transform.position.y <= -5.2 || transform.position.x >= 5.2 || transform.position.x <= -5.2)
        {
            Debug.Log("Dead @ " + transform.position.x + "," + transform.position.y + ", with speed " + deltaX + " , " + deltaY);
            Destroy(gameObject);
        }
        transform.position = transform.position + new Vector3(deltaX * Time.deltaTime, deltaY * Time.deltaTime);
    }

}
