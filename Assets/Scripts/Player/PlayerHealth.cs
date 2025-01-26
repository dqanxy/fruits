using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : BaseHealth
{
    public bool hasShield = false;

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
        else if (other.gameObject.CompareTag("Shield"))
        {
            hasShield = true;
            health = 2;
        }
    }

    public override void Die()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                SceneLoader.Instance.SetLevelDied(1);
                break;
            case "Level2":
                SceneLoader.Instance.SetLevelDied(2);
                break;
            case "Level3":
                SceneLoader.Instance.SetLevelDied(3);
                break;
        }

        
        SceneLoader.Instance.GameOver();
    }

}
