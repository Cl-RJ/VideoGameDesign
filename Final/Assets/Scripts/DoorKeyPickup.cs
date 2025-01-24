using UnityEngine;

public class DoorKeyPickup : MonoBehaviour
{
    // Visual effect parameters.
    public float rotationSpeed = 50f;
    public float bobbingSpeed = 2f;
    public float bobbingHeight = 0.25f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        float newY = initialPosition.y + Mathf.Abs(Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
         // Checks if robot object intersects with powerup and if so gives player inventory key.
        if (other.CompareTag("Robot"))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.HasKey = true;
                Destroy(gameObject);
            }
        }
    }
}