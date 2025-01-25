using System.Collections;
using UnityEngine;

public class PeriodicShoot : MonoBehaviour
{
    public float period;
    public GameObject projectile;

    void Start()
    {
        StartCoroutine(Shoot());
    }


    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(period);
            Instantiate(projectile);
            projectile.transform.position = transform.position;
        }
    }
}
