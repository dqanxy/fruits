using UnityEngine;
using System.Collections;

public class GenericEnemyShooter : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    [SerializeField] ShootingType shootingType = ShootingType.AtPlayer;

    [Tooltip("An euler angle to represent which angle to shoot when the shootingType is set to \"AtAngle\"")]
    //An angle in degrees of where to shoot. Only used when shootingType is set to "angle"
    [SerializeField] int shotAngle = 0;

    [SerializeField] float timeDelay = 0.5f;
    [SerializeField] float initialDelay = 0;

    float timer = 0;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = timeDelay;
        StartCoroutine(InitialDelay());
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Shoot();
            timer = timeDelay;
        }
    }

    public static Vector3 angleToDirection(int angle, Vector3 vec)
    {
        return Quaternion.Euler(0, 0, angle) * vec;
    }

    private IEnumerator InitialDelay()
    {
        yield return new WaitForSeconds(initialDelay);
    }
    public void Shoot()
    {
        Vector2 shootingDirection = Vector2.down;

        switch(shootingType)
        {
            case ShootingType.AtPlayer:
                if(PlayerController.Instance)
                {
                    shootingDirection = PlayerController.Instance.transform.position - transform.position;
                    shootingDirection = angleToDirection(shotAngle, shootingDirection);
                }
                break;
            case ShootingType.AtAngle:
                shootingDirection = angleToDirection(shotAngle, Vector3.right);
                break;

        }
        
        shootingDirection.Normalize();

        var bulletObj = Instantiate(bullet, transform.position, Quaternion.identity);
        var bulletData = bulletObj.GetComponent<EnemyBullet>();
        bulletData.Fire(shootingDirection);
    }

    private void OnDrawGizmosSelected()
    {
        if(shootingType == ShootingType.AtAngle)
        {
            Gizmos.DrawLine(transform.position, transform.position + angleToDirection(shotAngle, Vector2.right));
        }
    }
}

public enum ShootingType
{
    AtPlayer,
    AtAngle
}
