using UnityEngine;

public class SirenPlayerController : MonoBehaviour
{
    public GuardPatrol[] guards; // Array of references to all GuardPatrol scripts
    private AudioSource sirenAudio; // AudioSource for playing the siren sound

    [Header("Chase Sound Delay Settings")]
    public float chaseDelay = 1.0f; // Delay before confirming starting/stopping siren sound
    public float reduceFactor = 2.0f; // Speed at which chaseTimer reduces when guards stop chasing
    private float chaseTimer = 0.0f; // Timer to manage the delay

    private bool isSirenPlaying = false; // Track if the siren is currently playing

    void Start()
    {
        // Get the AudioSource component from this object
        sirenAudio = GetComponent<AudioSource>();

        // Check if AudioSource is attached
        if (sirenAudio == null)
        {
            Debug.LogWarning("SirenPlayerController: AudioSource component missing from SirenPlayer!");
        }
        else
        {
            // Set the volume to 50%
            sirenAudio.volume = 0.5f;
        }

        // Ensure the guards array is not empty
        if (guards == null || guards.Length == 0)
        {
            Debug.LogWarning("SirenPlayerController: No guards assigned!");
        }
    }

    void Update()
    {
        bool isAnyGuardChasing = false;

        // Check if any guard is in chasing state and is not paralyzed
        foreach (GuardPatrol guard in guards)
        {
            if (guard != null && guard.isChasing && !guard.isParalyzed)
            {
                isAnyGuardChasing = true;
                break;
            }
        }

        // Implement delay logic
        if (isAnyGuardChasing)
        {
            // If any guard is chasing and not paralyzed, increase the timer
            chaseTimer += Time.deltaTime;

            // If the timer exceeds the delay and siren is not playing, start playing
            if (chaseTimer >= chaseDelay && !isSirenPlaying)
            {
                if (sirenAudio != null)
                {
                    sirenAudio.Play();
                    isSirenPlaying = true; // Set the siren as playing
                    Debug.Log("Siren started after delay.");
                }
            }
        }
        else
        {
            // If no guard is chasing or all are paralyzed, decrease the timer
            chaseTimer -= Time.deltaTime * reduceFactor;

            // Ensure the timer doesn't go below zero
            if (chaseTimer <= 0)
            {
                chaseTimer = 0;

                // Stop the siren if it's currently playing
                if (isSirenPlaying && sirenAudio != null)
                {
                    sirenAudio.Stop();
                    isSirenPlaying = false; // Set the siren as not playing
                    Debug.Log("Siren stopped after delay.");
                }
            }
        }
    }
}
