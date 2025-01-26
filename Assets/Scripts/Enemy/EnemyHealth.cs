using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : BaseHealth
{
    public bool isBoss = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            Destroy(other.gameObject.gameObject.gameObject.gameObject.gameObject.gameObject);
            health -= 1;
        }
    }

    public override void Die()
    {
        if (isBoss)
        {
            StartCoroutine(NextLevel());
        }

        base.Die();
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(5);
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                SceneManager.LoadScene("Level2");
                break;
            case "Level2":
                SceneManager.LoadScene("Level3");
                break;
        }
    }
}
