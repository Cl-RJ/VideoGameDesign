using UnityEngine;

public class PlayerXRayVision : MonoBehaviour
{
    public Material xrayMaterial; // Reference to the X-Ray material
    public Material normalMaterial; // Reference to the original guard material
    public Camera xrayCamera; // Reference to the X-Ray Camera

    public float xrayDuration = 10.0f; // Duration of X-Ray Vision in seconds
    public bool isXRayActive = false; // Make this public
    public float xrayTimer = 0.0f;

    public float xrayCooldown = 15.0f; // Cooldown time for X-Ray Vision
    public float cooldownTimer = 0.0f; // Make this public

    public bool hasXRayVisionItem = false; // Whether the player has acquired the X-Ray item

    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Ensure X-Ray Camera is disabled at the start
        if (xrayCamera != null)
        {
            xrayCamera.enabled = false;
        }

        // Get the existing AudioSource component from the player object
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Handling X-Ray active timer
        if (isXRayActive)
        {
            xrayTimer -= Time.deltaTime;

            if (xrayTimer <= 0)
            {
                DisableXRayVision();
            }
        }

        // Handling cooldown timer
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // Activate X-Ray when pressing F if cooldown is complete
        if (hasXRayVisionItem && Input.GetKeyDown(KeyCode.F) && !isXRayActive && cooldownTimer <= 0)
        {
            ActivateXRayVision();
        }
    }

    public void ActivateXRayVision()
    {
        if (!isXRayActive)
        {
            isXRayActive = true;
            xrayTimer = xrayDuration; // Set the duration timer
            cooldownTimer = xrayCooldown; // Set the cooldown timer

            ApplyXRayVisionToGuards();

            // Enable X-Ray Camera when activated
            if (xrayCamera != null)
            {
                xrayCamera.enabled = true;
            }

            // Play the scanning sound effect
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
        }
    }

    public void DisableXRayVision()
    {
        isXRayActive = false;

        RemoveXRayVisionFromGuards();

        // Disable X-Ray Camera
        if (xrayCamera != null)
        {
            xrayCamera.enabled = false;
        }

        // Stop the scanning sound if it's still playing
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void ApplyXRayVisionToGuards()
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard");

        foreach (GameObject guard in guards)
        {
            Renderer guardRenderer = guard.GetComponent<Renderer>();
            if (guardRenderer != null)
            {
                guardRenderer.material = xrayMaterial;
            }
        }
    }

    public void RemoveXRayVisionFromGuards()
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard");

        foreach (GameObject guard in guards)
        {
            Renderer guardRenderer = guard.GetComponent<Renderer>();
            if (guardRenderer != null)
            {
                guardRenderer.material = normalMaterial;
            }
        }
    }
}
