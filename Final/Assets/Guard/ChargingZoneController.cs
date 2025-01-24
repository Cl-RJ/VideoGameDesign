using UnityEngine;
using TMPro;

public class ChargingZoneController : MonoBehaviour
{
    public TextMeshProUGUI messageText; // Reference to the TextMeshProUGUI to display messages
    public AudioClip levelCompleteMusic; // The music clip to play when the level is completed
    private AudioSource audioSource; // Reference to the AudioSource component
    private bool levelCompleted = false; // Track if the level is already completed
    
    public GameObject buttonContainer; // Reference to the button container

    private void Start()
    {
        // Add an AudioSource component to this gameObject
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // Prevent the music from playing on awake

        // Make sure the button container is hidden at the start
        if (buttonContainer != null)
        {
            buttonContainer.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player with tag "Robot" and level isn't completed yet
        if (other.CompareTag("Robot") && !levelCompleted)
        {
            levelCompleted = true; // Set the level as completed so it doesn't trigger again

            // Display the level complete message
            ShowMessage("Level Complete! Charging Successful!");

            // Show the button container for replay options
            if (buttonContainer != null)
            {
                buttonContainer.SetActive(true);
            }

            // Play the level complete music
            if (levelCompleteMusic != null && audioSource != null)
            {
                audioSource.clip = levelCompleteMusic;
                audioSource.Play();
            }
        }
    }

    private void ShowMessage(string message)
    {
        // Display the message on the TextMeshProUGUI
        if (messageText != null)
        {
            messageText.text = message;
            // Remove the Invoke for clearing message since we want it to persist
        }
    }
}
