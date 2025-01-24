using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionAI : MonoBehaviour
{
    public GameObject[] waypoints;
    private int currWaypoint = -1;
    private NavMeshAgent navMeshAgent;
    private Animator anim;
    public enum AIState {
        StationaryWaypoint,
        MovingWaypoint
    };
    public AIState aiState;
    public GameObject targetTracker;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        aiState = AIState.StationaryWaypoint;
        setNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        switch (aiState) {
            case AIState.StationaryWaypoint:
                if (waypoints[currWaypoint].GetComponent<Animator>() != null) {
                    aiState = AIState.MovingWaypoint;
                }
                break;
            case AIState.MovingWaypoint:
                if (waypoints[currWaypoint].GetComponent<Animator>() == null) {
                    aiState = AIState.StationaryWaypoint;
                } else {
                    UpdateTarget();
                }
                break;
            default:
                break;
        }
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance - navMeshAgent.stoppingDistance <= 0.5) {   
            setNextWaypoint();
        }
        anim.SetFloat("vely", navMeshAgent.velocity.magnitude / navMeshAgent.speed);
        targetTracker.transform.position = new Vector3(navMeshAgent.steeringTarget.x, targetTracker.transform.position.y, navMeshAgent.steeringTarget.z);
    }

    private void setNextWaypoint() {
        if (waypoints.Length == 0) {
            Debug.LogError("The waypoints array is empty!");
            return;
        }
        currWaypoint++;
        if (currWaypoint >= waypoints.Length) {
            currWaypoint = 0;
        }
        navMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
    }   

    private void UpdateTarget() {
        GameObject target = waypoints[currWaypoint];
        VelocityReporter vr = target.GetComponent<VelocityReporter>();
        if (vr != null) {
            float dist = (target.transform.position - this.transform.position).magnitude;
            Vector3 futureTarget = target.transform.position + (dist / navMeshAgent.speed) * vr.velocity;
            NavMeshHit hit;
            bool trueHit = NavMesh.Raycast(this.transform.position, futureTarget, out hit, NavMesh.AllAreas);   
            if (trueHit) {
                futureTarget = hit.position;
            }
            navMeshAgent.SetDestination(futureTarget);
        }
    }
}

