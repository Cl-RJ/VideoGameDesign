using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int playerScore = 0; // Track the player's score
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro component

    public void AddScore(int points)
    {
        playerScore += points; // Add points to the score
        UpdateScoreUI(); // Update the UI
    }

    public void AddCompletionPoint()
    {
        Debug.Log("Adding completion point for finishing the second game.");
        AddScore(1); // Add 1 point for completing the second game
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + playerScore.ToString();
        }
    }
}
