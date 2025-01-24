using UnityEngine;

public class TrapTriggerTile : MonoBehaviour
{
    public GameObject trapZone;
    public GameObject key;
    private bool hasKey = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot"))
        {
            if (!hasKey)
            {
                Debug.Log("This area is a trap zone, you need a key to activate it.");
            }
            else
            {
                ActivateTrapZone();
            }
        }
    }

    void ActivateTrapZone()
    {
        if (trapZone != null)
        {
            trapZone.SetActive(true);
            Debug.Log("Trap zone has been activated!");
        }
    }

    public void SetKeyAcquired()
    {
        hasKey = true;
    }
}
