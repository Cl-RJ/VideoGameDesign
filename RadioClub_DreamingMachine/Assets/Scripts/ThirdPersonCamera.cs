using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // The robot the camera will follow
    public Vector3 offset = new Vector3(0, 1, -3); // Offset for camera position
    public float smoothSpeed = 0.125f; // Speed of the smoothing for the camera
    public float rotationSmoothSpeed = 0.05f; // Speed of rotation smoothing

    private float currentYaw = 0f; // Control the camera's rotation around the robot
    private Vector3 currentOffset; // Store the smoothed offset
    private float yawVelocity = 0f; // Velocity for SmoothDampAngle
    private float targetPositionY; // Smoothed Y position

    void Start()
    {
        currentOffset = offset; // Initialize current offset
        targetPositionY = target.position.y + offset.y; // Initialize the Y position
    }

    void LateUpdate()
    {
        // Smoothly calculate the rotation angle around the Y axis (yaw)
        currentYaw = Mathf.SmoothDampAngle(currentYaw, target.eulerAngles.y, ref yawVelocity, rotationSmoothSpeed);

        // Smooth the Y position to filter out minor vertical shakes
        targetPositionY = Mathf.Lerp(targetPositionY, target.position.y + offset.y, smoothSpeed);

        // Calculate the desired position using the smoothed Y position
        Vector3 desiredPosition = target.position + Quaternion.Euler(0, currentYaw, 0) * offset;
        desiredPosition.y = targetPositionY; // Apply smoothed Y position separately

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Keep the camera looking at the robot
        transform.LookAt(target);
    }
}