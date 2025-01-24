using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform leftDoor;  // Reference to the left door
    public Transform rightDoor;  // Reference to the right door

    public float openDistance = 2f;  // How far each door will slide open
    public float doorSpeed = 2f;  // Speed at which the door moves

    private Vector3 leftClosedPosition;  // Closed position for the left door
    private Vector3 rightClosedPosition;  // Closed position for the right door
    private Vector3 leftOpenPosition;  // Open position for the left door
    private Vector3 rightOpenPosition;  // Open position for the right door

    public bool hasKey = false;  // Track if the robot has the key
    private bool isOpening = false;  // Whether the door should open

    void Start()
    {
        leftClosedPosition = leftDoor.position;
        rightClosedPosition = rightDoor.position;

        // Set the open positions by adjusting the x-axis:
        // Move the left door left (negative x) and the right door right (positive x)
        leftOpenPosition = leftClosedPosition + new Vector3(-openDistance, 0, 0);  // Left door slides to the left
        rightOpenPosition = rightClosedPosition + new Vector3(openDistance, 0, 0);  // Right door slides to the right
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot") && hasKey)  // Only open if the player has the key
        {
            isOpening = true;  // Start opening the doors
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Robot"))
        {
            isOpening = false;  // Close the doors when Robin leaves
        }
    }

    void Update()
    {
        if (isOpening)
        {
            // Move the doors to their open positions
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftOpenPosition, Time.deltaTime * doorSpeed);
            rightDoor.position = Vector3.Lerp(rightDoor.position, rightOpenPosition, Time.deltaTime * doorSpeed);
        }
        else
        {
            // Move the doors back to their closed positions
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftClosedPosition, Time.deltaTime * doorSpeed);
            rightDoor.position = Vector3.Lerp(rightDoor.position, rightClosedPosition, Time.deltaTime * doorSpeed);
        }
    }

    // This method can be called from another script when the player collects the key
    public void CollectKey()
    {
        hasKey = true;  // This will allow the doors to open
    }
}
