using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
{
    // Called when Replay button is pressed for Level 1
    public void LoadLevel1()
    {
        LoadSceneAdditively("Demo 2");
    }

    // Called when Replay button is pressed for Level 2
    public void LoadLevel2()
    {
        LoadSceneAdditively("Level2_Colonial");
    }

    // Called when Replay button is pressed for Level 3
    public void LoadLevel3()
    {
        LoadSceneAdditively("Level3");
    }

    // Called when Replay button is pressed for Level 4
    public void LoadLevel4()
    {
        LoadSceneAdditively("Level4");
    }

    // Helper function to load the scene additively and unload the current one
    private void LoadSceneAdditively(string sceneName)
    {
        // Load the specified scene in Additive mode
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);

        // Unload the current active scene
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name != sceneName)
        {
            // Deactivate the UI before unloading the scene to prevent overlap
            DisableUIElementsInCurrentScene();

            // Unload the current scene
            SceneManager.UnloadSceneAsync(currentScene);
        }
    }

    // Disable all UI elements in the current scene
    private void DisableUIElementsInCurrentScene()
    {
        Canvas[] canvases = FindObjectsOfType<Canvas>();
        foreach (Canvas canvas in canvases)
        {
            canvas.gameObject.SetActive(false);
        }
    }
}
