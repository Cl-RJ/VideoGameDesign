using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBean : MonoBehaviour
{
    private Rigidbody rb;
    public float force = 10f;
    public float rotationSpeed = 10f;
    public float minJumpInterval = 1f;
    public float maxJumpInterval = 7f;
    private float nextJumpTime;
    private int groundedCount = 0;

    private void Start() {
        rb = this.GetComponent<Rigidbody>();
        nextJumpTime = Time.time + Random.Range(minJumpInterval, maxJumpInterval);
    }

    private void FixedUpdate() {
        if (Time.time >= nextJumpTime && groundedCount > 0) {
            float magnitude = Random.Range(0.5f * force, 1.0f * force);
            rb.AddForce(Vector3.up * magnitude, ForceMode.Impulse); 
            rb.AddTorque(Vector3.forward * rotationSpeed, ForceMode.Impulse);
            nextJumpTime = Time.time + Random.Range(minJumpInterval, maxJumpInterval);
        }
    }

    void OnCollisionEnter(Collision c) {
        if (c.transform.gameObject.CompareTag("ground")) {
            groundedCount++;    
        }
    }

    private void OnCollisionExit(Collision c) {
        if (c.transform.gameObject.CompareTag("ground")) {
            groundedCount--;
        }
    }
    
    
}
