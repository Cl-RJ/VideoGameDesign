using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverPanel; // Reference to the Game Over UI Panel

    void Awake()
    {
        // Make this GameManager instance accessible from other scripts
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Called when the game is over
    public void GameOver()
    {
        // Display the Game Over UI Panel
        gameOverPanel.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;
    }

    // Restart the game by reloading the current scene
    public void RestartGame()
    {
        // Resume the game time before restarting
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
