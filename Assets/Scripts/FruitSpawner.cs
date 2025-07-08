using UnityEngine;
using UnityEngine.Pool;
using System.Collections;
using System.Collections.Generic;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private Fruit _fruitPrefab;
    [SerializeField] private float _spawnRadius = 5f;
    [SerializeField] private float _spawnInterval = 1f;
    [SerializeField] private int _poolCapacity = 3;
    [SerializeField] private int _poolMaxSize = 3;
    [SerializeField] private List<Point> _points = new List<Point>();

    private ObjectPool<Fruit> _pool;
    private Coroutine _spawningCoroutine;
    private int _activeCount = 0;

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
        _spawningCoroutine = StartCoroutine(SpawnRoutine());
    }

    private void OnDestroy()
    {
        StopCoroutine(_spawningCoroutine);
    }

#if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        _points.Clear();

        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out Point spawnPoint))
            {
                _points.Add(spawnPoint);
            }
        }
    }
#endif

    private IEnumerator SpawnRoutine()
    {
        WaitForSeconds waitForSpawnInterval = new WaitForSeconds(_spawnInterval);

        while (enabled)
        {
            yield return waitForSpawnInterval;

            if (_activeCount < _poolMaxSize)
                _pool.Get();
        }
    }

    private Fruit Create()
    {
        Fruit fruit = Instantiate(_fruitPrefab);
        fruit.ReturnToPool += Release;
        return fruit;
    }

    private void Enable(Fruit fruit)
    {
        fruit.transform.position = GetRandomSpawnPosition();
        fruit.gameObject.SetActive(true);
        _activeCount++;
    }

    private void Disable(Fruit fruit)
    {
        fruit.gameObject.SetActive(false);
        _activeCount--;
    }

    private void Destroy(Fruit fruit)
    {
        Destroy(fruit.gameObject);
    }

    private void Release(Fruit fruit)
    {
        _pool.Release(fruit);
    }
    
    private Vector2 GetRandomSpawnPosition()
    {
        return _points[UnityEngine.Random.Range(0, _points.Count)].transform.position;
    }
}
