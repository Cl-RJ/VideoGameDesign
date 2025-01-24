using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSphere : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        EventManager.TriggerEvent<BombBounceEvent, Vector3>(collision.contacts[0].point);
    }
}
