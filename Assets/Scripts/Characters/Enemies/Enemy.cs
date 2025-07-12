using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Patroler), typeof(Flipper), typeof(PlayerSearcher))]
[RequireComponent(typeof(Chaser), typeof(Damager))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private List<PatrolPoint> _patrolPoints;

    private Patroler _enemyPatroler;
    private Flipper _flipper;
    private PlayerSearcher _playerSearcher;
    private Chaser _chaser;

    private void Awake()
    {
        _enemyPatroler = GetComponent<Patroler>();
        _flipper = GetComponent<Flipper>();
        _playerSearcher = GetComponent<PlayerSearcher>();
        _chaser = GetComponent<Chaser>();
    }

    private void Start()
    {
        _enemyPatroler.Initialize(_patrolPoints);
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
}