using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform topSpawn;
    [SerializeField] private Transform leftSpawn;
    [SerializeField] private Transform rightSpawn;
    [SerializeField] private Transform bottomSpawn;

    public List<EnemyWave> waves = new List<EnemyWave>();

    public GameObject shieldPowerup;

    private void Start()
    {
        StartCoroutine(SpawnPowerup());
        foreach (var wave in waves)
        {
            if (wave != null)
            {
                StartCoroutine(SpawnWave(wave));
            }
        }
    }



    IEnumerator SpawnWave(EnemyWave wave)
    {
        yield return new WaitForSeconds(wave.time);
        switch (wave.spawnDirection)
        {
            case SpawnDirection.Top:
                Instantiate(wave.wave, new Vector3(topSpawn.position.x, topSpawn.position.y, 0), Quaternion.identity);
                break;

            case SpawnDirection.Bottom:
                Instantiate(wave.wave, new Vector3(bottomSpawn.position.x, bottomSpawn.position.y, 0), Quaternion.identity);
                break;

            case SpawnDirection.Left:
                Instantiate(wave.wave, new Vector3(leftSpawn.position.x, leftSpawn.position.y, 0), Quaternion.identity);
                break;

            case SpawnDirection.Right:
                Instantiate(wave.wave, new Vector3(rightSpawn.position.x, rightSpawn.position.y, 0), Quaternion.identity);
                break;
        }
    }

    IEnumerator SpawnPowerup()
    {
        yield return new WaitForSeconds(Random.Range(3.0f, 12.0f));
        Instantiate(shieldPowerup, new Vector3(topSpawn.position.x + Random.Range(-5.0f, 5.0f), topSpawn.position.y, 0), Quaternion.identity);
        StartCoroutine(SpawnPowerup());
    }
}
