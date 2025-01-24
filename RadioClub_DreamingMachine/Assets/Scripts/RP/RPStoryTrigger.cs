using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPStoryTrigger : MonoBehaviour
{
    public GameObject storyPanel;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the trigger zone
        if (other.CompareTag("Robot"))
        {
            ShowStoryPanel();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player has exited the trigger zone
        if (other.CompareTag("Robot"))
        {
            CloseStoryPanel();
        }
    }

    private void ShowStoryPanel()
    {
        // Enable the story panel to show it
        storyPanel.SetActive(true);
    }

    public void CloseStoryPanel()
    {
        // Disable the story panel to hide it
        storyPanel.SetActive(false);
    }
}
