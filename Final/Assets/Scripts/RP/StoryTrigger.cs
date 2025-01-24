using UnityEngine;
using TMPro; // Add this for TextMeshPro

public class StoryTrigger : MonoBehaviour
{
    [SerializeField] private TMP_Text storyText; // Change from Text to TMP_Text
    [SerializeField] private Canvas storyCanvas; // Drag the Canvas here
    [SerializeField] private string storyMessage; // Customize this for each pressure plate

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot")) // Check if the player is interacting
        {
            ShowStory(storyMessage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Robot"))
        {
            HideStory();
        }
    }

    private void ShowStory(string message)
    {
        storyText.text = message; // Set the text dynamically
        storyCanvas.enabled = true; // Show the canvas
    }

    private void HideStory()
    {
        storyCanvas.enabled = false; // Hide the canvas
    }
}
