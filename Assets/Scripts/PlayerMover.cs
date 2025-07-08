using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private const string Horizontal = "Horizontal";
    private const string Speed = "Speed";

    private Rigidbody2D _rb;
    private Animator _animator;
    private bool isFacingRight = true;
    private float _moveInput;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _moveInput = Input.GetAxisRaw(Horizontal);

        float moveX = Input.GetAxis(Horizontal) * _moveSpeed * Time.deltaTime;
        _rb.linearVelocity = new Vector2(_moveInput * _moveSpeed, _rb.linearVelocity.y);

        _animator.SetFloat(Speed, Mathf.Abs(_moveInput));

        if (_moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (_moveInput < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;  
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}