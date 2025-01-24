using UnityEngine;

public class KeyItemController : MonoBehaviour
{
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        // Get the AudioSource component from the KeyItem object
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player with tag "Robot"
        if (other.CompareTag("Robot"))
        {
            // Play the pickup sound effect
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // Notify the TriggerTile that the key has been collected
            FindObjectOfType<TriggerTileController>().CollectKey();

            // Delay the destruction of the key object until after the sound plays
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
