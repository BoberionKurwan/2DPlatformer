using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemySearcher : MonoBehaviour
{
    private CircleCollider2D _triggerCollider;
    private List<Enemy> _enemiesInRange = new List<Enemy>();

    private void Awake()
    {
        _triggerCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            _enemiesInRange.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            _enemiesInRange.Remove(enemy);
    }

    public Enemy GetClosestEnemy()
    {
        return _enemiesInRange
            .Where(enemy => enemy != null)
            .OrderBy(enemy => Vector3.Distance(transform.position, enemy.transform.position))
            .FirstOrDefault();
    }
}
