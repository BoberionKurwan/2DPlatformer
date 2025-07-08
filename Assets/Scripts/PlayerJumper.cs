using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _ground;

    private const string JumpTrigger = "Jump";
    private const string Grounded = "IsGrounded";
    private const string ExtraJumpTrigger = "ExtraJump";

    private Rigidbody2D _rb;
    private Animator _animator;
    private bool _isGrounded;
    private float _groundCheckRadius = 0.2f;

    private int _extraJumpsMax = 1;
    private int _extraJumpsLeft;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _extraJumpsLeft = _extraJumpsMax;
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _ground);

        _animator.SetBool(Grounded, _isGrounded);

        if (_isGrounded)
        {
            _extraJumpsLeft = _extraJumpsMax;
            ResetJumpTriggers();
        }

        if (Input.GetButtonDown(JumpTrigger) && _isGrounded)
        {
            _animator.SetTrigger(JumpTrigger);
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpForce);
        }
        else if (Input.GetButtonDown(JumpTrigger) && _extraJumpsLeft > 0)
        {
            _animator.SetTrigger(ExtraJumpTrigger);
            _extraJumpsLeft--;
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpForce);
        }
    }
    private void ResetJumpTriggers()
    {
        _animator.ResetTrigger(JumpTrigger);
        _animator.ResetTrigger(ExtraJumpTrigger);
    }
}
