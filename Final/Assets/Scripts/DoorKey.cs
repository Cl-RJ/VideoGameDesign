using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public SlidingDoor slidingDoor;  // Reference to the SlidingDoor script

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot"))  // Check if the player collects the key
        {
            slidingDoor.CollectKey();  // Notify the SlidingDoor script that the player has the key
            Destroy(gameObject);  // Destroy the key object after it's collected
        }
    }
}
