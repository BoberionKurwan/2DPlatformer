using System;
using UnityEngine;

[RequireComponent(typeof(CollectibleSearcher), typeof(Health))]
public class FruitWallet : MonoBehaviour
{
    private CollectibleSearcher _collectibleSearcher;
    private Health _health;
 
    private int _healthRestoreAmount = 1;
    private int _initialCount = 0;

    public event Action<int> FruitCountChanged;

    public int FruitCount {  get; private set; }

    private void Awake()
    {
        FruitCount = _initialCount;

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
        FruitCount++;
        _health.Restore(_healthRestoreAmount);
        FruitCountChanged?.Invoke(FruitCount);
    }
}
