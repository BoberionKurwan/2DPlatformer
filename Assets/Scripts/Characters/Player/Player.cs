using UnityEngine;

public class Player : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private Mover _mover;
    private Flipper _flipper;
    private Animation _animation;

    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _flipper = GetComponent<Flipper>();
        _animation = GetComponent<Animation>();
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
        _flipper.Flip(_inputReader.GetMoveInput());
    }
}