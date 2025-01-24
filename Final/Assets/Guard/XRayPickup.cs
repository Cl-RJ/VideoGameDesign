using UnityEngine;

public class XRayPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        PlayerXRayVision playerXRay = other.GetComponent<PlayerXRayVision>();
        if (playerXRay != null)
        {
            // If the player script exists, grant the ability to use X-Ray Vision
            playerXRay.hasXRayVisionItem = true;

            // Destroy the XRay pickup object
            Destroy(gameObject);
        }
    }
}
