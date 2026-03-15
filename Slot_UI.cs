using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot_UI : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI quantityText;

    private Inventory.Slot currentSlot;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        if (button == null)
        {
            Debug.LogWarning("Slot_UI: No Button component found.");
        }
    }

    public void SetItem(Inventory.Slot slot)
    {
        currentSlot = slot;

        if (slot != null && slot.type != CollectableType.NONE)
        {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
            quantityText.text = slot.count.ToString();

            if (button != null)
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(OnClickUseItem);
            }
        }
    }

    public void SetEmpty()
    {
        currentSlot = null;
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        quantityText.text = "";

        if (button != null)
        {
            button.onClick.RemoveAllListeners();
        }
    }

    private void OnClickUseItem()
    {
        if (currentSlot == null || currentSlot.type == CollectableType.NONE)
            return;

        if (currentSlot.type == CollectableType.MEDICINE)
        {
            Health health = FindObjectOfType<Health>();
            if (health != null && health.currentHealth < 100f)
            {
                float healAmount;
                if (CollectableDatabase.healValues.TryGetValue(currentSlot.type, out healAmount))
                {
                    health.TakeDamage(-healAmount); // Negative = heal
                    Debug.Log($"Player healed by {healAmount}");

                    // Use the item in inventory
                    PlayerController player = FindObjectOfType<PlayerController>();
                    if (player != null && player.inventory.UseItem(currentSlot.type))
                    {
                        // Refresh or clear the slot if count is 0
                        if (currentSlot.count <= 0)
                        {
                            SetEmpty();
                        }
                        else
                        {
                            SetItem(currentSlot); // Update count
                        }
                    }
                }
            }
        }
    }
}
