using UnityEngine;

public class Flipper : MonoBehaviour
{
    private const float RightRotation = 0f;
    private const float LeftRotation = 180f;

    public void Flip(float _moveInput)
    {
        if (_moveInput < 0)
            transform.rotation = Quaternion.Euler(0, LeftRotation, 0);
        else if (_moveInput > 0)
            transform.rotation = Quaternion.Euler(0, RightRotation, 0);
    }

    public void FlipTowardsTarget(Vector2 targetPosition)
    {
        if (targetPosition.x < transform.position.x)
            transform.rotation = Quaternion.Euler(0, LeftRotation, 0);
        else
            transform.rotation = Quaternion.Euler(0, RightRotation, 0);
    }
}