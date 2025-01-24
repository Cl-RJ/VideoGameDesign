using UnityEngine;

public class ClimbPowerUp : MonoBehaviour
{
    public float rotationSpeed = 50f; 
    public float bobbingSpeed = 2f;
    public float bobbingHeight = 0.25f;

    private Vector3 startPosition;

    // Start position of PowerUp
    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Handles visual effects for our PowerUp while idle.
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        float newY = startPosition.y + Mathf.Abs(Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Checks if our player intersects with PowerUp and updates its inventory and status.
        if (other.CompareTag("Robot"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.CanClimb = true;
            }
            Destroy(gameObject);
        }
    }
}