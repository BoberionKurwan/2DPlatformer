using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _initial = 100;
    private int _max = 100;

    public int Current { get; private set; }
    public int Max { get; private set; }

    public event Action Died;
    public event Action Changed;

    private void Awake()
    {
        Current = _initial;
        Max = _max;
    }

    public void TakeDamage(int damage)
    {
        Current -= damage;

        if (Current < 0)
        {
            Current = 0;
            Died?.Invoke();
        }

        Changed?.Invoke();
    }

    public void Restore(int healthAmount)
    {
        if (healthAmount >= 0)
            Current += healthAmount;

        if (Current > _max)
            Current = _max;

        Changed?.Invoke();
    }
}
