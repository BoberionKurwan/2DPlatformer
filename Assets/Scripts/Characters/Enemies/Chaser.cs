using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    public void Chase(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            target,
            _speed * Time.fixedDeltaTime);
    }
}
