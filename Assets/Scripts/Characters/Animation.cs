using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animation : MonoBehaviour
{
    private static readonly int JumpTrigger = Animator.StringToHash("Jump");
    private static readonly int DeathTrigger = Animator.StringToHash("Death");
    private static readonly int Grounded = Animator.StringToHash("IsGrounded");
    private static readonly int Speed = Animator.StringToHash("Speed");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAnimatorSpeed(float moveInput) => 
        _animator.SetFloat(Speed, Mathf.Abs(moveInput));

    public void SetAnimatorJumpTrigger() => 
        _animator.SetTrigger(JumpTrigger);

    public void SetAnimatorBool(bool isGrounded) => 
        _animator.SetBool(Grounded,isGrounded);

    public void SetAnimatorDeathTrigger() =>
        _animator.SetTrigger(DeathTrigger);
}