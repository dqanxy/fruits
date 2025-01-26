using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : BaseHealth
{
    public bool hasShield = false;
    public GameObject shield;
    public float shieldTime = 5;
    public float invincibleTimeAfterShieldEnd = 0.5f;

    private void Start()
    {
        hasShield = false;
        shield.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyProjectile"))
        {
            if (other.gameObject.CompareTag("EnemyProjectile"))
            {
                Destroy(other.gameObject.gameObject.gameObject.gameObject.gameObject.gameObject);
            }

            if (!hasShield)
            {
                health -= 1;
            }
            else
            {
                StartCoroutine(EndShield());
            }

            
            
        }
        else if (other.gameObject.CompareTag("Shield"))
        {
            StartCoroutine(StartShield());
            Destroy(other.gameObject.gameObject.gameObject.gameObject.gameObject.gameObject);
        }
    }

    public override void Die()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                Debug.Log("Level1 Ded");
                SceneLoader.Instance.SetLevelDied(1);
                break;
            case "Level2":
                Debug.Log("Level2 Ded");
                SceneLoader.Instance.SetLevelDied(2);
                break;
            case "Level3":
                Debug.Log("Level3 Ded");
                SceneLoader.Instance.SetLevelDied(3);
                break;
        }

        
        SceneLoader.Instance.GameOver();
    }

    IEnumerator StartShield()
    {
        hasShield = true;
        shield.SetActive(true);
        yield return new WaitForSeconds(shieldTime);
        //hasShield = false;
        //shield.SetActive(false);
    }

    IEnumerator EndShield()
    {
        shield.SetActive(false);
        yield return new WaitForSeconds(invincibleTimeAfterShieldEnd);
        hasShield = false;
    }



}
