using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _maxHealth = 3;
    private int _initialHealth = 3;

    public int CurrentHealth { get; private set; }

    public event Action PlayerDied;

    private void Awake()
    {
        CurrentHealth = _initialHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
            PlayerDied?.Invoke();
        }
    }

    public void RestoreHealth(int healthAmount)
    {
        CurrentHealth += healthAmount;

        if (CurrentHealth > _maxHealth)
            CurrentHealth = _maxHealth;
    }
}
