using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStayTimer : MonoBehaviour
{
    public GameObject glassDoor; // Reference to the glass door
    public float countdownTime = 60f; // Countdown time in seconds
    private bool isCountdownActive = false; // Check if the countdown is active
    private float timer; // Current time left

    private Collider glassDoorCollider;
    private Renderer glassDoorRenderer;

    public ScoreManager scoreManager; // Reference to the ScoreManager
    private bool hasAwardedScore = false; // Check if the score has been awarded
    private bool gameStarted = false; // Check if the second game has started

    void Start()
    {
        timer = countdownTime; // Initialize the timer

        if (scoreManager != null)
        {
            Debug.Log("ScoreManager assigned successfully.");
        }
        else
        {
            Debug.LogError("ScoreManager is not assigned!");
        }

        // Get the glass door's components
        if (glassDoor != null)
        {
            glassDoorCollider = glassDoor.GetComponent<Collider>();
            glassDoorRenderer = glassDoor.GetComponent<Renderer>();

            if (glassDoorCollider != null) glassDoorCollider.enabled = false;
            if (glassDoorRenderer != null) glassDoorRenderer.enabled = false;
        }
    }

    void Update()
    {
        if (isCountdownActive && gameStarted)
        {
            timer -= Time.deltaTime;
            Debug.Log("Timer: " + timer);

            if (timer <= 0)
            {
                timer = 0; // Clamp timer to 0
                isCountdownActive = false; // Stop the countdown
                RemoveGlassDoor(); // Remove the door
                AwardCompletionPoint(); // Add a score point only once
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot")) // Ensure the robot is tagged as "Robot"
        {
            if (!gameStarted)
            {
                Debug.Log("Robot entered the room. Countdown started.");
                gameStarted = true; // Mark the game as started
                isCountdownActive = true; // Start the countdown

                // Form the glass door
                if (glassDoorCollider != null) glassDoorCollider.enabled = true;
                if (glassDoorRenderer != null) glassDoorRenderer.enabled = true;
            }
        }
    }

    private void RemoveGlassDoor()
    {
        Debug.Log("Countdown complete. Glass door removed.");
        if (glassDoor != null)
        {
            if (glassDoorCollider != null) glassDoorCollider.enabled = false;
            if (glassDoorRenderer != null) glassDoorRenderer.enabled = false;
        }
    }

    private void AwardCompletionPoint()
    {
        if (!hasAwardedScore && gameStarted)
        {
            hasAwardedScore = true;
            if (scoreManager != null)
            {
                scoreManager.AddScore(1); // Add 1 point to the score
                Debug.Log("Awarded 1 point for completing the second game!");
            }
            else
            {
                Debug.LogError("ScoreManager not assigned in RoomStayTimer!");
            }
        }
    }
}
