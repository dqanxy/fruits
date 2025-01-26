using System.Collections;
using UnityEngine;

public class NormalEnemyShoot : MonoBehaviour
{
    public bool allowShooting = false;
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
        yield return new WaitForSeconds(initialDelay);
        while (allowShooting)
        {
            
            if (GetComponent<BaseHealth>() && GetComponent<BaseHealth>().health > maxHPForAttack)
            {
                continue;
            }
            projectile.transform.position = transform.position;
            Instantiate(projectile);

            yield return new WaitForSeconds(period);


        }
    }
}