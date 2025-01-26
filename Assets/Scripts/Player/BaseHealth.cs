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

    public virtual void Die()
    {
        Destroy(gameObject);
    }

}
