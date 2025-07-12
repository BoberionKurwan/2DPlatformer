using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[RequireComponent(typeof(CollectibleSearcher))]
public class FruitWallet : MonoBehaviour
{
    private CollectibleSearcher _collectibleSearcher;
    private int _fruitCount = 0;

    public event Action<int> FruitCountChanged;

    private void Awake()
    {
        _collectibleSearcher = GetComponent<CollectibleSearcher>();
        _collectibleSearcher.foundFruit += IncreaseFruitCount;
    }

    private void OnDestroy()
    {
        _collectibleSearcher.foundFruit -= IncreaseFruitCount;
    }

    private void IncreaseFruitCount()
    {
        _fruitCount++;
        FruitCountChanged?.Invoke(_fruitCount);
    }

    public int GetCurrentCount() => _fruitCount;
}
