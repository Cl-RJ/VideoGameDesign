using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTaskGlassDoor : MonoBehaviour
{
    public ScoreManager scoreManager; // Reference to the ScoreManager
    private Collider glassDoorCollider; // Reference to the door's collider
    private Renderer glassDoorRenderer; // Reference to the door's renderer

    void Start()
    {
        // Get the glass door's components
        glassDoorCollider = GetComponent<Collider>();
        glassDoorRenderer = GetComponent<Renderer>();

        if (glassDoorCollider == null || glassDoorRenderer == null)
        {
            Debug.LogError("Glass door is missing Collider or Renderer components!");
        }

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager is not assigned in FinalTaskGlassDoor!");
        }

        UpdateGlassDoorState(); // Set initial state
    }

    void Update()
    {
        UpdateGlassDoorState();
    }

    private void UpdateGlassDoorState()
    {
        if (scoreManager != null)
        {
            if (scoreManager.playerScore >= 5)
            {
                // Hide the glass door
                glassDoorCollider.enabled = false;
                glassDoorRenderer.enabled = false;
                Debug.Log("Glass door removed as score reached 5 or more.");
            }
            else
            {
                // Show the glass door
                glassDoorCollider.enabled = true;
                glassDoorRenderer.enabled = true;
                Debug.Log("Glass door is active as score is less than 5.");
            }
        }
    }
}
