using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Patroler), typeof(Flipper))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private List<PatrolPoint> _patrolPoints;
    private Patroler _enemyPatroler;
    private Flipper _flipper;

    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
        _enemyPatroler = GetComponent<Patroler>();
        _enemyPatroler.Initialize(_patrolPoints);
    }

    private void FixedUpdate()
    {
        _enemyPatroler.Patrol();
        _flipper.FlipTowardsTarget(_enemyPatroler.GetCurrentTargetPosition());
    }
}