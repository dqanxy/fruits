using UnityEngine;

public class PlayerHealth : BaseHealth
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyProjectile"))
        {
            if (other.gameObject.CompareTag("EnemyProjectile"))
            {
                Destroy(other.gameObject.gameObject.gameObject.gameObject.gameObject.gameObject);
            }
            health -= 1;
        }
    }

    public override void Die()
    {
        SceneLoader.Instance.GameOver();
    }

}
