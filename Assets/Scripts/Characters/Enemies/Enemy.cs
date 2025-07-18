using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Patroler), typeof(Flipper))]
[RequireComponent(typeof(Chaser), typeof(Damager), typeof(Health))]
public class Enemy : MonoBehaviour
{
    private static readonly int DeathTrigger = Animator.StringToHash("Death");

    [SerializeField] private PlayerSearcher _playerSearcher;
    [SerializeField] private List<PatrolPoint> _patrolPoints;
    [SerializeField] private Animation _animation;

    private Patroler _enemyPatroler;
    private Flipper _flipper;
    private Chaser _chaser;
    private Health _health;

    private void Awake()
    {
        _enemyPatroler = GetComponent<Patroler>();
        _flipper = GetComponent<Flipper>();
        _chaser = GetComponent<Chaser>();
        _health = GetComponent<Health>();
     }

    private void Start()
    {
        _health.Died += OnDie;
        _enemyPatroler.Initialize(_patrolPoints);
    }

    private void OnDestroy()
    {
        _health.Died -= OnDie;
    }

    private void FixedUpdate()
    {
        if (_playerSearcher.Target == null)
        {
            _enemyPatroler.Patrol();
            _flipper.FlipTowardsTarget(_enemyPatroler.GetCurrentTargetPosition());
        }
        else
        {
            _chaser.Chase(_playerSearcher.Target.transform.position);
            _flipper.FlipTowardsTarget(_playerSearcher.Target.transform.position);
        }
    }

    private void OnDie()
    {
        _animation.SetAnimatorDeathTrigger();
        StartCoroutine(DestroyAfterAnimation());
    }

    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSecondsRealtime(1f);
        Destroy(gameObject);
    }
}