using UnityEngine;

[System.Serializable]
public class EnemyWave
{
    public GameObject wave;
    public float time;
    public SpawnDirection spawnDirection;
}

public enum SpawnDirection
{
    Top,
    Left,
    Right,
    Bottom
}
