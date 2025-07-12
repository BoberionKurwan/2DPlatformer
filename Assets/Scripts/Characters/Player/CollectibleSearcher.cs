using System;
using UnityEngine;

public class CollectibleSearcher : MonoBehaviour
{    
    public event Action FoundFruit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Fruit>(out Fruit fruit))
        {
            FoundFruit.Invoke();
            fruit.FruitCollected();
        }
    }
}