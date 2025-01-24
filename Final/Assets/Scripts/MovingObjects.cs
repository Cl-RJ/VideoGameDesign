using UnityEngine;

public class MovingObjects: MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding is the player
        if (other.CompareTag("Player"))
        {
            // Get the RobotPower script from the player
            RobotPower2 robotPower = other.GetComponent<RobotPower2>();

            if (robotPower != null)
            {
                // Reduce the robot's power by 10%
                robotPower.ReducePower(10f);
            }
        }
    }
}


