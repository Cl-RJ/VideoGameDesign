using UnityEngine;

public class ChargingStation : MonoBehaviour
{
    public float rechargeRate = 10f; // Rate at which the robot charges per second
    public float chargeRadius = 5f; // Radius within which the robot can charge
    public Light chargeLight; // Light indicator for charging station
    public LineRenderer lineRenderer; // Visual effect for charging connection
    public Transform wireStartPoint; // Starting point for the charging wire effect
    public float maxCharge = 100f; // Maximum charge capacity of the station (in percent)
    
    private bool isCharging = false;
    private Transform robotTransform;
    private Transform robotCenter; // Center point of the robot
    private float currentCharge; // Current available charge in the station
    private float pulseSpeed = 2f; // Speed of the pulsing effect
    private float minIntensity = 3f; // Minimum pulsing intensity
    private float maxIntensity = 5f; // Maximum pulsing intensity
    private float chargingIntensity = 5f; // Intensity when charging

    void Start()
    {
        currentCharge = maxCharge; // Set current charge to max charge at start

        if (chargeLight != null)
        {
            chargeLight.intensity = minIntensity;
        }

        if (lineRenderer != null)
        {
            lineRenderer.enabled = false;
        }
    }

    void Update()
    {
        // Check if there's any charge left and turn off light if there is none.
        if (currentCharge <= 0f)
        {
            if (chargeLight != null)
            {
                chargeLight.intensity = 0f;
            }
            if (lineRenderer != null)
            {
                lineRenderer.enabled = false;
            }
            return;
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, chargeRadius);
        isCharging = false;
        robotTransform = null;
        robotCenter = null;

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Robot"))
            {
                RobotPower robotPower = collider.GetComponent<RobotPower>();
                if (robotPower != null)
                {
                    float energyToTransfer = rechargeRate * Time.deltaTime;

                    if (energyToTransfer > currentCharge)
                    {
                        energyToTransfer = currentCharge;
                    }

                    float actualRecharged = robotPower.Recharge(energyToTransfer);
                    currentCharge -= actualRecharged;

                    if (actualRecharged > 0)
                    {
                        isCharging = true;
                        robotTransform = collider.transform;
                        robotCenter = collider.transform.Find("RobotCenter") ?? robotTransform;
                    }
                }
            }
        }

        // Light effect to represent when charging or chargable still.
        if (chargeLight != null)
        {
            if (isCharging)
            {
                chargeLight.intensity = chargingIntensity;
            }
            else
            {
                chargeLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(Time.time * pulseSpeed, 1));
            }
        }

        // Line Renderer handling for visual charging effect to show player when connected.
        if (lineRenderer != null)
        {
            if (isCharging && robotCenter != null)
            {
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, wireStartPoint.position);
                lineRenderer.SetPosition(1, robotCenter.position);
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chargeRadius);
    }
}