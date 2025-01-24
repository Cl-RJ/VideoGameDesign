using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneTransition2 : MonoBehaviour
{
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the number of graves left is 0
            MingMingGameManager gameManager = FindObjectOfType<MingMingGameManager>();
            if (gameManager != null && gameManager.GetGravesLeft() == 0)
            {
                LoadNextScene();
            }
            else
            {
                Debug.Log("Cannot transition to the next scene. Graves are still remaining.");
            }
        }
    }

    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not set in the inspector!");
        }
        
        // Optional: Adjust render settings for the new scene
        RenderSettings.ambientLight = Color.white; 
        RenderSettings.skybox = null;
    }
}

