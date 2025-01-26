using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : BaseHealth
{
    public bool isBoss = false;
    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            Destroy(other.gameObject.gameObject.gameObject.gameObject.gameObject.gameObject);
            health -= 1;
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            health -= 1;
        }
        SFXManager.Instance?.PlayEnemyHitSFX();

    }

    public override void Die()
    {

        if (isBoss)
        {
            StartCoroutine(NextLevel());
        }
        else
            SFXManager.Instance?.PlayEnemyDeathSFX();


        base.Die();
    }

    IEnumerator NextLevel()
    {
        // Create 5 explosions sequentially
        for (int i = 0; i < 5; i++)
        {
            Instantiate(explosion,
                new Vector3(
                    gameObject.transform.position.x + Random.Range(-1.0f, 1.0f),
                    gameObject.transform.position.y + Random.Range(-1.0f, 1.0f),
                    0),
                Quaternion.identity);

            yield return new WaitForSeconds(0.2f); // Wait between explosions
        }

        // Wait briefly after the explosions
        yield return new WaitForSeconds(1f);

        // Debug log for tracking
        Debug.Log("NextLevel");

        // Transition to the next level
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                SceneManager.LoadScene("Level2");
                break;
            case "Level2":
                SceneManager.LoadScene("Level3");
                break;
            default:
                Debug.LogWarning("No next level defined!");
                break;
        }
    }

    IEnumerator Explode(float time)
    {
        Instantiate(explosion, new Vector3(gameObject.transform.position.x + Random.Range(-1.0f, 1.0f), gameObject.transform.position.y, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.1f* time);
    }
}
