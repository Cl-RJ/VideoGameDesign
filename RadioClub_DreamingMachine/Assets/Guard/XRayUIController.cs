using UnityEngine;
using TMPro;

public class XRayUIController : MonoBehaviour
{
    public PlayerXRayVision playerXRayVision; // Reference to the PlayerXRayVision script
    public TextMeshProUGUI xrayUIText; // Reference to the Text UI

    void Start()
    {
        // Hide the X-Ray UI text initially
        xrayUIText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerXRayVision == null || xrayUIText == null)
            return;

        // If the player has the X-Ray vision item, show the UI
        if (playerXRayVision.hasXRayVisionItem)
        {
            xrayUIText.gameObject.SetActive(true);
            UpdateUIText();
        }
    }

    void UpdateUIText()
    {
        if (playerXRayVision.isXRayActive)
        {
            xrayUIText.text = "X-Ray Active! Time Remaining: " + Mathf.Ceil(playerXRayVision.xrayTimer) + "s";
        }
        else if (playerXRayVision.cooldownTimer > 0)
        {
            xrayUIText.text = "X-Ray Cooldown: " + Mathf.Ceil(playerXRayVision.cooldownTimer) + "s";
        }
        else
        {
            xrayUIText.text = "Press 'F' to activate X-Ray";
        }
    }
}
