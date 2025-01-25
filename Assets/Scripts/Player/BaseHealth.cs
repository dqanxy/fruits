using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public int health = 1;

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("PlayerProjectile"))
    //    {
    //        Destroy(other.gameObject.gameObject.gameObject.gameObject.gameObject.gameObject);
    //        HP -= 1;
    //    }
    //}
}
