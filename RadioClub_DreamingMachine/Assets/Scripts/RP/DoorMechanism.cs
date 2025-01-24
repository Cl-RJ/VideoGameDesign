using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanism : MonoBehaviour
{
    public Animator doorAnimator; // Assign in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot")) // Replace "Player" with "Robot" if necessary
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Robot")) // Replace "Player" with "Robot" if necessary
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open");
        }
    }

    private void CloseDoor()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Close");
        }
    }
}
