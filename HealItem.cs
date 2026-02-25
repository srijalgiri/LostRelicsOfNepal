// using UnityEngine;
// using UnityEngine.UI;

// public class HealItem : MonoBehaviour
// {
//     public PlayerController playerController; // reference directly
//     public string itemName = "HealthPotion"; // name in inventory
//     public int healAmount = 20;

//     private void Start()
//     {
//         GetComponent<Button>().onClick.AddListener(UseHealItem);
//     }

//     void UseHealItem()
//     {
//         if (playerController != null)
//         {
//             Inventory inventory = playerController.inventory;
//             Damageable damageable = playerController.GetComponent<Damageable>();

//             if (inventory != null && damageable != null)
//             {
//                 if (inventory.HasItem(itemName))
//                 {
//                     bool healed = damageable.Heal(healAmount);
//                     if (healed)
//                     {
//                         inventory.UseItem(itemName);
//                         Debug.Log($"Used {itemName}. Remaining: {inventory.GetCount(itemName)}");
//                     }
//                     else
//                     {
//                         Debug.Log("Heal failed: already at full health or dead.");
//                     }
//                 }
//                 else
//                 {
//                     Debug.Log("No healing items left!");
//                 }
//             }
//         }
//     }
// }
