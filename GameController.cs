using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameOverManager gameOverManager; // Assign in Inspector
    [SerializeField] private float reloadDelay = 2f; // Optional delay before reload

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOver();
        }
        else
        {
            Debug.LogWarning("GameOverManager is not assigned!");
        }

        Invoke(nameof(ReloadScene), reloadDelay); // Reload after delay
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads current scene
    }
}
