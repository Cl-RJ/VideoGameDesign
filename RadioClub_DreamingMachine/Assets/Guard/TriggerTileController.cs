using UnityEngine;
using TMPro;

public class TriggerTileController : MonoBehaviour
{
    public GameObject trapZone; // Reference to the trap zone GameObject
    public float trapRiseHeight = 1.5f; // Height by which the trap zone will rise
    public float trapSpeed = 1f; // Speed at which the trap will rise
    public TextMeshProUGUI messageText; // Reference to the TextMeshProUGUI to display messages
    private bool hasKey = false; // Tracks whether the player has the key
    private bool isTrapActivated = false; // Tracks whether the trap has been activated
    private bool isRaisingTrap = false; // Tracks if the trap is currently being raised
    private Vector3 targetPosition; // The target position for the trap
    private AudioSource trapAudioSource; // Reference to the AudioSource for trapZone
    private AudioSource triggerAudioSource; // Reference to the AudioSource for triggerTile (for hint sound)

    private void Start()
    {
        // Get the AudioSource component from the trapZone object
        if (trapZone != null)
        {
            trapAudioSource = trapZone.GetComponent<AudioSource>();
        }

        // Get the AudioSource component from the triggerTile object (itself)
        triggerAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player with tag "Robot"
        if (other.CompareTag("Robot"))
        {
            if (!hasKey)
            {
                // Display a message if the player doesn't have the key
                ShowMessage("This area is a trap. You need a key to activate it!");

                // Play the hint sound effect if the key is not collected
                if (triggerAudioSource != null)
                {
                    triggerAudioSource.Play();
                }
            }
            else if (!isTrapActivated) // Check if the trap is not already activated
            {
                // Display a message and activate the trap if the player has the key
                ShowMessage("The trap is now activated!");
                ActivateTrap();
            }
        }
    }

    private void Update()
    {
        // Smoothly raise the trap if it is currently being raised
        if (isRaisingTrap && trapZone != null)
        {
            trapZone.transform.position = Vector3.MoveTowards(trapZone.transform.position, targetPosition, trapSpeed * Time.deltaTime);

            // Stop raising when the target position is reached
            if (trapZone.transform.position == targetPosition)
            {
                isRaisingTrap = false;
                isTrapActivated = true; // Mark the trap as activated once it reaches the target
            }
        }
    }

    private void ActivateTrap()
    {
        // Set the target position and start raising the trap
        if (trapZone != null)
        {
            targetPosition = trapZone.transform.position + new Vector3(0, trapRiseHeight, 0);
            isRaisingTrap = true; // Start raising the trap smoothly
            
            // Play the raising sound effect
            if (trapAudioSource != null)
            {
                trapAudioSource.Play();
            }
        }
    }

    public void CollectKey()
    {
        // Called when the player collects the key
        hasKey = true;
        ShowMessage("Key acquired! You can now activate the trap.");
    }

    private void ShowMessage(string message)
    {
        // Display the message on the TextMeshProUGUI
        if (messageText != null)
        {
            messageText.text = message;
            Invoke("ClearMessage", 3f); // Clear the message after 3 seconds
        }
    }

    private void ClearMessage()
    {
        // Clear the message from the TextMeshProUGUI
        if (messageText != null)
        {
            messageText.text = "";
        }
    }
}
