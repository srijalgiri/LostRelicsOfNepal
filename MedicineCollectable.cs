using UnityEngine;

public class MedicineCollectable : MonoBehaviour
{
    public float healAmount = 10f;

    private void OnMouseDown()
    {
        HealPlayer();
    }

    void HealPlayer()
    {
        Health health = FindObjectOfType<Health>();
        if (health != null && health.currentHealth < 100) // Assuming 100 is max
        {
            float newHealth = Mathf.Min(health.currentHealth + healAmount, 100f);
            health.TakeDamage(-healAmount); // Negative damage = healing
            Destroy(gameObject); // Remove the medicine after use
        }
    }
}
