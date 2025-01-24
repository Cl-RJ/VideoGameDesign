using UnityEngine;

public class GuardCollision : MonoBehaviour
{
    // This function is called when the guard collides with another object
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "Robot" (i.e., the player)
        if (collision.collider.CompareTag("Robot"))
        {
            // Call the GameManager to handle the game over logic
            GameManager.Instance.GameOver();
        }
    }
}
