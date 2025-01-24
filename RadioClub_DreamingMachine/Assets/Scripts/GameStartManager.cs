using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public GameObject instructionPanel; // Reference to the instruction panel
    public GameObject robot; // Reference to the robot GameObject
    
    public GameObject gameOverPanel;

    public GameObject gameWinPanel;

    void Start()
    {
        // Show the instruction panel at the start
        instructionPanel.SetActive(true);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (gameWinPanel != null)
            gameWinPanel.SetActive(false);

        if (robot != null)
            robot.SetActive(false);
        
    }

    public void StartGame()
    {
        // Hide the instruction panel
        instructionPanel.SetActive(false);

        // Enable the robot
        if (robot != null)
            robot.SetActive(true);

        Debug.Log("Game Started!");
    }
}

