using System;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public event Action<Fruit> ReturnToPool;

    private SpawnPoint _spawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out _))
        {
            ReturnToPool.Invoke(this);
        }
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