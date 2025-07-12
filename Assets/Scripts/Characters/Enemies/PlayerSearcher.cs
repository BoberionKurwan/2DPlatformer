using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerSearcher : MonoBehaviour
{
    public Player Target { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            Target = player;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            Target = null;
        }
    }
}