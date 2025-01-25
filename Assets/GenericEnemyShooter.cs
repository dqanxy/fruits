using UnityEngine;

public class GenericEnemyShooter : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    [SerializeField] ShootingType shootingType = ShootingType.AtPlayer;

    [Tooltip("An euler angle to represent which angle to shoot when the shootingType is set to \"AtAngle\"")]
    //An angle in degrees of where to shoot. Only used when shootingType is set to "angle"
    [SerializeField] int shotAngle = 0;

    [SerializeField] float timeDelay = 0.5f;
    float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = timeDelay;
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

    public static Vector3 angleToDirection(int angle)
    {
        return Quaternion.Euler(0, 0, angle) * Vector3.right;
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
                }
                break;
            case ShootingType.AtAngle:
                shootingDirection = angleToDirection(shotAngle);
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
            Gizmos.DrawLine(transform.position, transform.position + angleToDirection(shotAngle));
        }
    }
}

public enum ShootingType
{
    AtPlayer,
    AtAngle
}
