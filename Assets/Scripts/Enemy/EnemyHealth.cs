using UnityEngine;

public class EnemyHealth : BaseHealth
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            Destroy(other.gameObject.gameObject.gameObject.gameObject.gameObject.gameObject);
            health -= 1;
        }
    }
}
