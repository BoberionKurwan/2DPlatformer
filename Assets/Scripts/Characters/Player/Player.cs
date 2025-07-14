using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GroundDetector), typeof(InputReader), typeof(Mover))]
[RequireComponent(typeof(Flipper), typeof(Animation), typeof(Health))]
public class Player : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private Mover _mover;
    private Flipper _flipper;
    private Animation _animation;
    private Health _health;

    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _flipper = GetComponent<Flipper>();
        _animation = GetComponent<Animation>();
        _health = GetComponent<Health>();
    }

    private void Start()
    {
        _health.Died += OnPlayerDied;
    }

    private void OnDestroy()
    {
        _health.Died -= OnPlayerDied;
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
            _mover.Move(_inputReader.Direction);

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _mover.Jump();
            _animation.SetAnimatorJumpTrigger();
        }

        _animation.SetAnimatorSpeed(_inputReader.Direction);
        _animation.SetAnimatorBool(_groundDetector.IsGround);
        _flipper.Flip(_inputReader.Direction);
    }

    private void OnPlayerDied()
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