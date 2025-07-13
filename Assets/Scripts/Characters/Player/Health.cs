using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _max = 3;
    private int _initial = 3;

    public int Current { get; private set; }

    public event Action Died;

    private void Awake()
    {
        Current = _initial;
    }

    public void TakeDamage(int damage)
    {
        Current -= damage;

        if (Current < 0)
        {
            Current = 0;
            Died?.Invoke();
        }
    }

    public void Restore(int healthAmount)
    {
        if (healthAmount >= 0)
            Current += healthAmount;

        if (Current > _max)
            Current = _max;
    }
}
