using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RobotPower : MonoBehaviour
{
    public float maxPower = 100f;
    private float currentPower;
    public float decayRate = 1f;
    private float decayTimer;
    public TextMeshProUGUI powerUIText;
    
    public float CurrentPower
    {
        get { return currentPower; }
    }

    void Start()
    {
        currentPower = maxPower;
        UpdatePowerUI();
    }

    void Update()
    {
        decayTimer += Time.deltaTime;
        if (decayTimer >= 3f)
        {
            currentPower = Mathf.Max(0, currentPower - decayRate);
            UpdatePowerUI();
            decayTimer = 0;

            // Check if power has run out
            if (currentPower <= 0)
            {
                RestartScene();
            }
        }
    }

    private void UpdatePowerUI()
    {
        powerUIText.text = $"Power: {currentPower}%";
    }

    public float Recharge(float amount)
    {
        float powerBeforeRecharge = currentPower;
        currentPower = Mathf.Min(maxPower, currentPower + amount);
        float actualRecharged = currentPower - powerBeforeRecharge; // Calculate actual amount recharged
        UpdatePowerUI();
        return actualRecharged; // Return the actual amount recharged
    }

    private void RestartScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}