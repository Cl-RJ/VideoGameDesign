using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For Text UI

public class PressurePlateManager : MonoBehaviour
{
    [System.Serializable]
    public class PressurePlateData
    {
        public GameObject plate;    // The pressure plate GameObject
        public string storyText;   // The text to display for this plate
    }

    public List<PressurePlateData> plates; // Assign all pressure plates and their texts in the Inspector
    public Text storyPanelText;           // Reference to the Text component in the UI
    public GameObject storyPanel;         // Reference to the StoryPanel GameObject

    private void Start()
    {
        // Ensure the story panel is initially hidden
        storyPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot")) // Replace "Robot" with your player's tag
        {
            // Check which plate is triggered
            foreach (var plate in plates)
            {
                if (other.gameObject == plate.plate)
                {
                    ShowStoryPanel(plate.storyText);
                    break;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Robot"))
        {
            CloseStoryPanel();
        }
    }

    private void ShowStoryPanel(string text)
    {
        storyPanelText.text = text; // Update the UI text
        storyPanel.SetActive(true); // Show the panel
    }

    private void CloseStoryPanel()
    {
        storyPanel.SetActive(false); // Hide the panel
    }
}
