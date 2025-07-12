using System;
using UnityEngine;

[RequireComponent(typeof(CollectibleSearcher), typeof(Health))]
public class FruitWallet : MonoBehaviour
{
    private CollectibleSearcher _collectibleSearcher;
    private Health _health;
 
    private int _fruitCount = 0;
    private int _healthRestoreAmount = 1;

    public event Action<int> FruitCountChanged;

    private void Awake()
    {
        _collectibleSearcher = GetComponent<CollectibleSearcher>();
        _health = GetComponent<Health>();
    }

    private void Start()
    {
        _collectibleSearcher.FoundFruit += IncreaseFruitCount;

    }

    private void OnDestroy()
    {
        _collectibleSearcher.FoundFruit -= IncreaseFruitCount;
    }

    private void IncreaseFruitCount()
    {
        _fruitCount++;
        _health.RestoreHealth(_healthRestoreAmount);
        FruitCountChanged?.Invoke(_fruitCount);
    }

    public int GetCurrentCount() => _fruitCount;
}
