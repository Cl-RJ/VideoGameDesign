using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayBallController : MonoBehaviour
{
    public GameObject[] hallwayBalls; // Array to hold all hallway balls

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot")) // Replace "Player" with your player tag if necessary
        {
            HideBalls();
        }
    }

    void HideBalls()
    {
        foreach (GameObject ball in hallwayBalls)
        {
            if (ball != null)
            {
                ball.SetActive(false); // Disable the ball to make it invisible
            }
        }

        Debug.Log("All hallway balls turned invisible");
    }
}
