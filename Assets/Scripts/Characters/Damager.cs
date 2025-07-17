using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private int _damage = 25;

    private float _damageCooldown = 1f;

    private float _lastDamageTime;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Attack(collision.collider);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Attack(collision.collider);
    }

    private void Attack(Collider2D collider)
    {
        if (Time.time - _lastDamageTime < _damageCooldown) 
            return;

        if (collider.TryGetComponent<Health>(out  var health))
        {
            health.TakeDamage(_damage);
            _lastDamageTime = Time.time;
        }
    }
}
