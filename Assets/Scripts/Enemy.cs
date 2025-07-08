using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 3f;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _reachThreshold = 0.1f;

    private Transform _currentTarget;
    private bool _movingToB = true;
    private bool _isFacingRight = true;

    private void Start()
    {
        _currentTarget = _pointB;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            _currentTarget.position,
            _movementSpeed * Time.deltaTime);

        CheckDirection();

        if (((Vector2)transform.position).IsEnoughClose(_currentTarget.position, _reachThreshold))
        {
            SwitchTarget();
        }
    }

    private void SwitchTarget()
    {
        _currentTarget = _movingToB ? _pointA : _pointB;
        _movingToB = !_movingToB;
    }

    private void CheckDirection()
    {
        // Определяем направление к цели
        bool shouldFaceRight = _currentTarget.position.x > transform.position.x;

        // Если направление изменилось - делаем Flip
        if (shouldFaceRight != _isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}