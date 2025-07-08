using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]
public class Fruit : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    public event Action<Fruit> ReturnToPool;

    private void Start()
    {
        if (_collider == null)
            _collider = GetComponent<Collider2D>();

        _collider.isTrigger = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMover>(out _))
        {
            ReturnToPool.Invoke(this);
        }
    }
}
