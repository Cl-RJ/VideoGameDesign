using UnityEngine;

public class GuardCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Guard Collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Robot"))
        {

            GuardPatrol guardPatrol = GetComponent<GuardPatrol>();


            if (guardPatrol != null && !guardPatrol.isParalyzed)
            {
                Debug.Log("Player detected - Triggering Game Over");

                GameManager gameManager = FindObjectOfType<GameManager>();
                if (gameManager != null)
                {
                    gameManager.GameOver();
                }
            }
            else
            {
                Debug.Log("Guard is paralyzed - Game Over not triggered");
            }
        }
    }
}
