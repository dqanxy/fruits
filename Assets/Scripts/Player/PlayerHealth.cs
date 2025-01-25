using UnityEngine;

public class PlayerHealth : BaseHealth
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject.gameObject.gameObject.gameObject.gameObject.gameObject);
            health -= 1;
        }
    }

}
