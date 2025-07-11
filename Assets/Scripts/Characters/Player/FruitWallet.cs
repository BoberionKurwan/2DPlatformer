using System;
using UnityEngine;

public class FruitWallet : MonoBehaviour
{
    CollectibleSearcher _collectibleSearcher;
    private int _fruitCount = 0;

    public event Action<int> FruitCountChanged;

    private void Start()
    {
        _collectibleSearcher = GetComponent<CollectibleSearcher>();
        _collectibleSearcher.foundFruit += IncreaseFruitCount;
    }

    private void IncreaseFruitCount()
    {
        _fruitCount++;
        FruitCountChanged?.Invoke(_fruitCount);
    }

    public int GetCurrentCount()
    {
        return _fruitCount;
    }
}
