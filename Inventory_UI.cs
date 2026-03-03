using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject inventoryPanel;

    [Header("References")]
    public PlayerController player;

    [Header("UI Slots")]
    public List<Slot_UI> slots = new List<Slot_UI>();

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Inventory_UI: Player reference not assigned!");
        }

        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false); // Hide at start
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if (inventoryPanel == null) return;

        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Setup();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }

    void Setup()
    {
        if (player == null || player.inventory == null)
        {
            Debug.LogWarning("Inventory_UI: Player or inventory is null during Setup.");
            return;
        }

        if (slots.Count != player.inventory.slots.Count)
        {
            Debug.LogWarning($"Inventory_UI: Slot count mismatch — UI slots = {slots.Count}, Inventory slots = {player.inventory.slots.Count}");
            return;
        }

        for (int i = 0; i < slots.Count; i++)
        {
            var invSlot = player.inventory.slots[i];
            if (invSlot.type != CollectableType.NONE)
            {
                Debug.Log($"Setting slot {i} with item {invSlot.type}, count: {invSlot.count}");
                slots[i].SetItem(invSlot);
            }
            else
            {
                Debug.Log($"Clearing slot {i}");
                slots[i].SetEmpty();
            }
        }
    }
}
