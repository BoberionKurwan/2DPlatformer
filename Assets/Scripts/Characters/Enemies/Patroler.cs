using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(PatrolPoint))]
public class Patroler : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private List<PatrolPoint> _patrolPoints;
    private PatrolPoint _currentTarget;
    private int _currentTargetIndex = 0;

    private float _distanceToTarget = 0.1f;

    public void Initialize(List<PatrolPoint> patrolPoints)
    {
        _patrolPoints = patrolPoints;
        _currentTarget = _patrolPoints[_currentTargetIndex];
    }

    public void Patrol()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            _currentTarget.transform.position,
            _speed * Time.fixedDeltaTime);

        if (IsTargetReached())
        {
            SelectNextPoint();
        }
    }

    public Vector2 GetCurrentTargetPosition()
    {
        return _currentTarget.transform.position;
    }

    private bool IsTargetReached()
    {
        return ((Vector2)transform.position).
            IsEnoughClose(_currentTarget.transform.position, _distanceToTarget);
    }

    private void SelectNextPoint()
    {
        _currentTargetIndex = ++_currentTargetIndex % _patrolPoints.Count;
        _currentTarget = _patrolPoints[_currentTargetIndex];
    }
}