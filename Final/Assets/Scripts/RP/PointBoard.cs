using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBoard : MonoBehaviour
{
    public int points = 1; // Points awarded for stepping on the board
    private bool hasTriggered = false; // Ensure the board is triggered only once

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot") && !hasTriggered) // Replace "Player" with your player tag if necessary
        {
            hasTriggered = true; // Prevent multiple triggers
            
            // Find the ScoreManager and add points
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(points);
            }

            // Optionally, make the board visually react
            DisableBoard();
        }
    }

    void DisableBoard()
    {
        // Disable or change appearance after triggering
        GetComponent<Renderer>().material.color = Color.gray; // Example: Dim the board
        gameObject.SetActive(false); // Make the board disappear
    }
}
