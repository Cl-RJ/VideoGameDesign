using UnityEngine;
using TMPro;

public class RobotPower2 : MonoBehaviour
{
    public float maxPower = 100f; 
    private float currentPower; 
    public float decayRate = 1f; 
    public TextMeshProUGUI powerUIText; 
    public GameObject gameOverPanel;
    void Start()
    {
        currentPower = maxPower; 
        UpdatePowerUI();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    void Update()
    {
        // Gradually decay power
        currentPower = Mathf.Max(0, currentPower - (decayRate * Time.deltaTime));
        UpdatePowerUI();

        // Check if power has dropped to 0
        if (currentPower <= 0)
        {
            EndGame();
        }
    }

    private void UpdatePowerUI()
    {
        powerUIText.text = $"Power: {Mathf.RoundToInt(currentPower)}%";
    }

    private void EndGame()
    {
        // Display the Game Over Panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // Stop the game (optional)
        Time.timeScale = 0f;

        Debug.Log("Game Over! Power depleted.");
    }

    public float Recharge(float amount)
    {
        float powerBeforeRecharge = currentPower;
        currentPower = Mathf.Min(maxPower, currentPower + amount);
        float actualRecharged = currentPower - powerBeforeRecharge;
        UpdatePowerUI(); 
        return actualRecharged; 
    }

    public void ReducePower(float amount)
    {
        currentPower = Mathf.Max(0, currentPower - amount); // Reduce power but prevent it from going below 0
        UpdatePowerUI();
    }
}
