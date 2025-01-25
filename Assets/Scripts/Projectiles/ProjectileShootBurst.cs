using System.Collections;
using UnityEngine;

public class ProjectileShootBurst : MonoBehaviour
{
    public float period;
    public int burstCount;
    public GameObject projectile;


    void Start()
    {
        StartCoroutine(Shoot());
    }


    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(Random.Range(.75f, period));
        for (int i = 0; i < burstCount; i++)
        {
            float dx = Mathf.Cos((2 * 3.14f) * ((i * 1.0f) / burstCount));
            float dy = Mathf.Sin((2 * 3.14f) * ((i * 1.0f) / burstCount));
            Instantiate(projectile);
            projectile.transform.position = transform.position;
            projectile.GetComponent<ProjectileMoveDir>().dx = dx;
            projectile.GetComponent<ProjectileMoveDir>().dy = dy;
        }
    }

}
