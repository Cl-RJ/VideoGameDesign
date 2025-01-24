using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public int level = 0;
    private int score = 0;
    private int targetScore = 10; // Change to 3 to match your test setup

    void Start()
    {
        UpdateLevelText();
    }

    public void AddScore(int points)
    {
        score += points;

        if (score >= targetScore)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        score = 0; // Reset score or adjust as needed
        UpdateLevelText();
    }

    private void UpdateLevelText()
    {
        levelText.text = "Level: " + level;
    }
}
