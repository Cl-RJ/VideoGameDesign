using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot") && !isOpen)
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null && playerInventory.HasKey)
            {
                animator.SetTrigger("Open");
                isOpen = true; // Prevents setting the trigger more than once
            }
        }
    }
}