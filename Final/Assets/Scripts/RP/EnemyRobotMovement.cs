using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRobotMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float changeDirectionInterval = 2f;
    private Vector3 moveDirection;
    private Rigidbody rb;

    public EnemyGameManager enemyGameManager; // Reference to the EnemyGameManager

    // Room boundaries
    public float minX = -0.339f;
    public float maxX = 9.277f;
    public float minZ = -4.69f;
    public float maxZ = 5.192f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChangeDirection();
        InvokeRepeating(nameof(ChangeDirection), changeDirectionInterval, changeDirectionInterval);
    }

    void Update()
    {
        MoveRobot();
    }

    void ChangeDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        moveDirection = new Vector3(randomX, 0, randomZ).normalized;

        // Update rotation to face movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * moveSpeed);
        }
    }

    void MoveRobot()
    {
        // Move the robot in the current direction
        Vector3 newPosition = rb.position + moveDirection * moveSpeed * Time.deltaTime;

        // Constrain the position within the room boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        // Lock the Y-axis to ensure the robot stays grounded
        newPosition.y = rb.position.y;

        rb.MovePosition(newPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Robot"))
        {
            Debug.Log("Player caught by enemy robot! Restarting the task...");
            if (enemyGameManager != null)
            {
                enemyGameManager.RestartGame();
            }
            else
            {
                Debug.LogError("EnemyGameManager not assigned!");
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy"))
        {
            ChangeDirection();
        }
    }
}
