using UnityEngine;

public static class VectorExtensions
{
    public static float SqrDistance(this Vector2 start, Vector2 end)
    {
        return (end - start).sqrMagnitude;
    }

    public static bool IsEnoughClose(this Vector2 start, Vector2 end, float distance)
    {
        return start.SqrDistance(end) <= distance * distance;
    }
}