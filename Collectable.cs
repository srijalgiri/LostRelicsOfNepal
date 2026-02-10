using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    [SerializeField] private Sprite icon;
    [SerializeField] private float healAmount = 20f; // ✅ Add this field

    public Sprite Icon => icon;
    public float HealAmount => healAmount; // ✅ Provide read-only access

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();

        if (playerController)
        {
            playerController.inventory.Add(type, icon);
// Pass this collectable object
            Debug.Log("Collected: " + type);
            Destroy(this.gameObject);
        }
    }
}
