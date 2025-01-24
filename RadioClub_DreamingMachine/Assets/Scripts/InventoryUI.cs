using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public TMP_Text inventoryTMPText;

    void Start()
    {
        if (inventoryTMPText == null)
        {
            Debug.LogError("Inventory TMP Text UI element is not assigned!");
        }
    }

    void Update()
    {
        UpdateInventoryDisplay();
    }

    void UpdateInventoryDisplay()
    {
        // Set initial font size
        inventoryTMPText.fontSize = 36;
        int itemCount = 0;

        // Start with base text and count items
        string displayText = "Inventory:\n";
        if (playerInventory.HasKey)
        {
            displayText += "- Key\n";
            itemCount++;
        }
        if (playerInventory.CanClimb)
        {
            displayText += "- Climbing Ability\n";
            itemCount++;
        }

        // Adjust font size based on item count to fit bounds
        if (itemCount > 3)
        {
            inventoryTMPText.fontSize = 28; // Reduce size if many items
        }

        inventoryTMPText.text = displayText;
    }
}