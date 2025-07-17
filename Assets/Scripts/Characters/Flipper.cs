using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private Transform _sprite;

    private const float RightRotation = 0f;
    private const float LeftRotation = 180f;

    public void Flip(float moveInput)
    {
        if (moveInput < 0)
            _sprite.rotation = Quaternion.Euler(0, LeftRotation, 0);
        else if (moveInput > 0)
            _sprite.rotation = Quaternion.Euler(0, RightRotation, 0);
    }

    public void FlipTowardsTarget(Vector2 targetPosition)
    {
        float direction = targetPosition.x - transform.position.x;
        Flip(direction);
    }
}