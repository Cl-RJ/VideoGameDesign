using UnityEngine;

public class ObjectPressurePlate : MonoBehaviour
{
    public GameObject door;
    private int objectsOnPlate = 0;

    private void OnTriggerEnter(Collider other)
    {
        // Handles opening when crate is detected.
        if (other.CompareTag("Crate"))
        {
            if (objectsOnPlate == 0)
            {
                door.GetComponent<PressurePlateDoor>().OpenDoor();
            }
            objectsOnPlate++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Crate"))
        {
            objectsOnPlate--;
            if (objectsOnPlate <= 0)
            {
                door.GetComponent<PressurePlateDoor>().CloseDoor();
                objectsOnPlate = 0;
            }
        }
    }
}