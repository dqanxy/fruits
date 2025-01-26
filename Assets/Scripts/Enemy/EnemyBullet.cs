using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 1;
    [SerializeField] float bulletTimeToDestroy = 10f;

    Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    public void Fire(Vector2 direction)
    {
        rb2d.linearVelocity = direction * bulletSpeed;
        rb2d.SetRotation(Quaternion.FromToRotation(Vector3.up, direction));
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(bulletTimeToDestroy);
        Destroy(gameObject);
    }
}
