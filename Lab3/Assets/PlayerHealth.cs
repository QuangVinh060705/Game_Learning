using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public event Action<int> OnHealthChanged;
    public event Action OnPlayerDied;

    void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(0, currentHealth);

        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            OnPlayerDied?.Invoke();
        }
    }
}
