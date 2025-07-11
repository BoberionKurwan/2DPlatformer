using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private List<Fruit> _fruits;
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private int _poolCapacity = 3;
    [SerializeField] private int _poolMaxSize = 3;
    [SerializeField] private int _maxActiveFruits = 5;

    private ObjectPool<Fruit> _pool;
    private List<SpawnPoint> _availableSpawnPoints = new List<SpawnPoint>();

    private void Awake()
    {
        _pool = new ObjectPool<Fruit>(
            createFunc: Create,
            actionOnGet: Enable,
            actionOnRelease: Disable,
            actionOnDestroy: Destroy,
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void Start()
    {
        _availableSpawnPoints = new List<SpawnPoint>(_spawnPoints);
        int spawnCount = Mathf.Min(_maxActiveFruits, _availableSpawnPoints.Count);

        for (int i = 0; i < spawnCount; i++)
        {
            _pool.Get();
        }
    }

    private Fruit Create()
    {
        Fruit fruit = Instantiate(_fruits[Random.Range(0, _fruits.Count)]);
        fruit.ReturnToPool += Release;
        return fruit;
    }

    private void Enable(Fruit fruit)
    {
        int randomIndex = Random.Range(0, _availableSpawnPoints.Count);
        SpawnPoint spawnPoint = _availableSpawnPoints[randomIndex];

        fruit.transform.position = spawnPoint.transform.position;
        fruit.SetSpawnPoint(spawnPoint);
        _availableSpawnPoints.RemoveAt(randomIndex);

        fruit.gameObject.SetActive(true);
    }

    private void Disable(Fruit fruit)
    {
        fruit.gameObject.SetActive(false);
        _availableSpawnPoints.Add(fruit.GetSpawnPoint());
        fruit.ReleaseSpawnPoint();
    }

    private void Destroy(Fruit fruit)
    {
        Destroy(fruit.gameObject);
    }

    private void Release(Fruit fruit)
    {
        _pool.Release(fruit);
    }

#if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        _spawnPoints.Clear();

        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out SpawnPoint spawnPoint))
            {
                _spawnPoints.Add(spawnPoint);
            }
        }
    }
#endif
}