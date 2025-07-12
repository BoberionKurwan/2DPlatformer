using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animation : MonoBehaviour
{
    private const string JumpTrigger = "Jump";
    private const string DeathTrigger = "Death";
    private const string Grounded = "IsGrounded";
    private const string Speed = "Speed";

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