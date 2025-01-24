using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBall : MonoBehaviour
{
    public int pointValue = 1; // Default point value, set to 1 for blue, 2 for yellow

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot")) // Player tag should match robotSphere tag
        {
            // Find the LevelSystem script and add points
            LevelSystem levelSystem = FindObjectOfType<LevelSystem>();
            if (levelSystem != null)
            {
                levelSystem.AddScore(pointValue);
            }

            // Destroy the ball after collection
            Destroy(gameObject);
        }
    }
}
