using System.Collections;
using UnityEngine;

public class PeriodicShoot : MonoBehaviour
{
    public float period;
    public float initialDelay;
    public GameObject projectile;
    public int maxHPForAttack = 9999;

    void Start()
    {
        StartCoroutine(Shoot());
    }


    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(period);
        while (true)
        {

            if(GetComponent<BaseHealth>() && GetComponent<BaseHealth>().health > maxHPForAttack)
            {
                continue;
            }
            Instantiate(projectile);
            projectile.transform.position = transform.position;

            yield return new WaitForSeconds(period);
        }
    }
}
