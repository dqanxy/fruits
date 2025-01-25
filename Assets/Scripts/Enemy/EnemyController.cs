using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int HP = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            Destroy(other.gameObject.gameObject.gameObject.gameObject.gameObject);
            HP -= 1;
        }
    }
}
