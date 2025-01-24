using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public Button restartButton;
    public Button quitButton;
    public Button instructionButton;
    public GameObject instructionsPanel;


    private bool isPaused = false;

    void Start()
    {
        pauseMenuPanel.SetActive(false);
        instructionsPanel?.SetActive(false);

        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
        instructionButton.onClick.AddListener(ShowInstructions);
    }

    void Update()
    {
        // Listen for the Escape key to toggle the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        // Pause the game and show the pause menu
        Time.timeScale = 0f;
        pauseMenuPanel.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        // Resume the game and hide the pause menu
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
        instructionsPanel?.SetActive(false); // Ensure instructions are hidden if open
        isPaused = false;
    }

    void RestartGame()
    {
        // Restart the current scene
        Time.timeScale = 1f; // Ensure time scale is reset
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void QuitGame()
    {
        // Quit the application
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in editor
        #endif
    }

    void ShowInstructions()
    {
        // Show the instructions panel
        instructionsPanel.SetActive(true);
    }
}
