using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    [SerializeField] private GameOverManager gameOverManager;

    [System.Serializable]
    public class HealthChangedEvent : UnityEvent<int, int> { } // (currentHealth, maxHealth)
    public HealthChangedEvent healthChanged;

    private void Awake()
    {
        currentHealth = startingHealth;

        // Trigger UI update at start
        if (healthChanged != null)
            healthChanged.Invoke((int)currentHealth, (int)startingHealth);
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        // Always update UI
        if (healthChanged != null)
            healthChanged.Invoke((int)currentHealth, (int)startingHealth);

        if (currentHealth > 0)
        {
            // Player hurt (play animation, sound, etc.)
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player is dead");
        // Optional: Disable movement, play death animation
        gameOverManager.ShowGameOver();
    }
}
