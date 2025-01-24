using UnityEngine;

public class ChargingStation2 : MonoBehaviour
{
    public float rechargeRate = 10f;
    public float chargeRadius = 5f;
    public Light chargeLight;
    public LineRenderer lineRenderer;
    public Transform wireStartPoint;
    public float maxCharge = 100f;

    private bool isCharging = false;
    private bool hasChargedOnce = false;
    private Transform robotTransform;
    private Transform robotCenter;
    private float currentCharge;
    private float chargingTimer = 0f;
    private float maxChargingDuration = 5f;
    private float pulseSpeed = 2f;
    private float minIntensity = 3f;
    private float maxIntensity = 5f;
    private float chargingIntensity = 5f;

    void Start()
    {
        currentCharge = maxCharge;
        if (chargeLight != null) chargeLight.intensity = minIntensity;
        if (lineRenderer != null) lineRenderer.enabled = false;
    }

    void Update()
    {
        if (hasChargedOnce || currentCharge <= 0f)
        {
            if (chargeLight != null) chargeLight.intensity = 0f;
            if (lineRenderer != null) lineRenderer.enabled = false;
            return;
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, chargeRadius);
        isCharging = false;
        robotTransform = null;
        robotCenter = null;

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                RobotPower2 robotPower = collider.GetComponent<RobotPower2>();
                MingMingGameManager gameManager = FindObjectOfType<MingMingGameManager>();

                if (robotPower != null && gameManager != null)
                {
                    int gravesLeft = gameManager.GetGravesLeft();
                    float energyToTransfer = 0f;

                    if (gravesLeft <= 3 && chargingTimer < maxChargingDuration)
                    {
                        energyToTransfer = rechargeRate * Time.deltaTime;

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
                            chargingTimer += Time.deltaTime;
                        }
                    }

                    if (chargingTimer >= maxChargingDuration)
                    {
                        hasChargedOnce = true;
                    }
                }
            }
        }

        if (chargeLight != null)
        {
            if (isCharging) chargeLight.intensity = chargingIntensity;
            else chargeLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(Time.time * pulseSpeed, 1));
        }

        if (lineRenderer != null)
        {
            if (isCharging && robotCenter != null)
            {
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, wireStartPoint.position);
                lineRenderer.SetPosition(1, robotCenter.position);
            }
            else lineRenderer.enabled = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chargeRadius);
    }
}


