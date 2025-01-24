using UnityEngine;

public class GraveBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the robot has the "Player" tag
        {
            // Notify the GameManager to decrease the grave count
            MingMingGameManager gameManager = FindObjectOfType<MingMingGameManager>();
            if (gameManager != null)
            {
                gameManager.DecreaseGraveCount();
            }

            // Make the grave disappear
            gameObject.SetActive(false);
        }
    }
}


