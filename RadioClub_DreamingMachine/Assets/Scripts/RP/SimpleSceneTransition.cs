using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneTransition : MonoBehaviour
{
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            LoadNextScene();
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
        RenderSettings.ambientLight = Color.white; // Adjust based on your needs
        RenderSettings.skybox = null;
    }


}
