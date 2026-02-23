using UnityEngine;

public class InstantDeathObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (health != null && health.currentHealth > 0)
        {
            health.TakeDamage(health.currentHealth); // Reduces to 0, triggers GameOver
        }
    }
}
