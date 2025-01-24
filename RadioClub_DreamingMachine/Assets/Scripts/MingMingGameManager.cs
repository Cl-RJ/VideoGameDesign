using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MingMingGameManager : MonoBehaviour
{
    public int totalGraves = 6; 
    public TextMeshProUGUI graveCounterText; 
    //public GameObject winGamePanel;

    void Start()
    {
        // Initialize the UI with the total number of graves
        UpdateGraveCounterUI();

        // if (winGamePanel != null)
        // {
        //     winGamePanel.SetActive(false);
        // }
    }

    public void DecreaseGraveCount()
    {
        totalGraves--;

        // Update the UI text
        UpdateGraveCounterUI();

        // Check if all graves are found
        // if (totalGraves <= 0)
        // {
        //     ShowWinPanel();
        // }
    }

    private void UpdateGraveCounterUI()
    {
        if (graveCounterText != null)
        {
            graveCounterText.text = "Graves Left: " + totalGraves;
        }
    }

    public int GetGravesLeft()
    {
        return totalGraves;
    }

    public void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

