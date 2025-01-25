using System.Collections;
using UnityEngine;

public class PeriodicShoot : MonoBehaviour
{
    public float period;
    public GameObject projectile;
    public int maxHPForAttack = 9999;

    void Start()
    {
        StartCoroutine(Shoot());
    }


    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(period);
            if(GetComponent<BaseHealth>() && GetComponent<BaseHealth>().health > maxHPForAttack)
            {
                continue;
            }
            Instantiate(projectile);
            projectile.transform.position = transform.position;
        }
    }
}
