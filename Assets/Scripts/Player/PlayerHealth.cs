using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public event Action<float, float> OnHealthChenge;
    public event Action OnDie;

    [SerializeField] private GameStateManager _gameStateManager;
    [SerializeField] private float _maxHealth;
    private float _currentHealth;

    private void Start()
    {
        SetHealth(_maxHealth);
    }

    public void TakeDamage(float value)
    {
        float newHealth = _currentHealth - value;
        newHealth = Mathf.Max(newHealth, 0);

        SetHealth(newHealth);

        if (newHealth == 0)
        {
            Die();
        }
    }

    private void SetHealth(float value)
    {
        _currentHealth = value;
        OnHealthChenge?.Invoke(_currentHealth,_maxHealth);
    }

    private void Die()
    {
        OnDie?.Invoke();
        _gameStateManager.SetLoseState();
        Debug.Log("Die");
    }
}
