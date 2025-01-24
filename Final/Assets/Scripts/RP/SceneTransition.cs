using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string nextSceneName; // Name of the next scene to load
    public int requiredLevel = 1; // Minimum level required to transition to the next scene
    private LevelSystem levelSystem; // Reference to the LevelSystem

    private void Start()
    {
        // Find the LevelSystem in the scene (ensure LevelSystem is attached to an active GameObject)
        levelSystem = FindObjectOfType<LevelSystem>();
        if (levelSystem == null)
        {
            Debug.LogError("LevelSystem not found in the scene. Please ensure it's added.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the Player tag
        if (other.CompareTag("Robot") && levelSystem != null && levelSystem.level >= requiredLevel)
        {
            LoadNextScene();
        }
        else if (other.CompareTag("Robot"))
        {
            Debug.Log("Player does not meet the required level to transition.");
        }
    }

    private void LoadNextScene()
    {
        // Load the next scene by name
        SceneManager.LoadScene(nextSceneName);
    }
}