using System;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public event Action<Fruit> ReturnToPool;

    private SpawnPoint _spawnPoint;

    public void FruitCollected()
    {
        ReturnToPool.Invoke(this);
    }

    public void SetSpawnPoint(SpawnPoint spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    public SpawnPoint GetSpawnPoint()
    {
        return _spawnPoint;
    }

    public void ReleaseSpawnPoint()
    {
        _spawnPoint = null;
    }
}