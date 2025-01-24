using UnityEngine;
using UnityEngine.AI;

public class GuardPatrol : MonoBehaviour {
    // Array of patrol points, to be assigned in the inspector
    public Transform[] patrolPoints;

    // Trap zone reference
    public Transform trapZone; // Reference to the trap zone object

    // Index of the current patrol point
    private int currentPatrolIndex = 0;

    // Guard's NavMeshAgent component
    private NavMeshAgent agent;

    // Player target
    public Transform player;

    // View range parameters
    public float viewDistance = 10.0f; // Viewing distance
    public float viewAngle = 60.0f; // Viewing angle

    // Chasing parameters
    public bool isChasing = false;

    // Searching parameters
    private bool isSearching = false;
    [Header("Search Settings")]
    public float searchDuration = 5.0f; // Duration of search state
    private float searchTimer = 0.0f; // Timer for search state

    // Array of search points for structured search
    private Vector3[] searchPoints;
    private int currentSearchPointIndex = 0;

    // Last known position of the player
    private Vector3 lastKnownPosition;

    // Paralyze state
    public bool isParalyzed = false;

    // Guard's Renderer component to change color
    private Renderer guardRenderer;
    private Color originalColor;

    // Audio source for playing siren sound
    private AudioSource sirenAudio;

    void Start() {
        // Get the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        // Get the Renderer component and save the original color
        guardRenderer = GetComponent<Renderer>();
        originalColor = guardRenderer.material.color;

        // Get the AudioSource component for the siren sound
        sirenAudio = GetComponent<AudioSource>();
        //sirenAudio = transform.Find("audio").GetComponent<AudioSource>();
        
        // If there are patrol points, set the first destination
        if (patrolPoints.Length > 0) {
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }

    void Update() {
        // If the guard is paralyzed, do nothing
        if (isParalyzed) {
            agent.isStopped = true;
            return;
        }

        // If chasing the player
        if (isChasing) {
            HandleChase();
        } else if (isSearching) {
            HandleSearch();
        } else {
            Patrol();

            // Check if the player is within view range
            if (CanSeePlayer()) {
                isChasing = true; // Start chasing
                guardRenderer.material.color = Color.blue; // Change color to blue when chasing
                agent.stoppingDistance = 0.2f; // Set stopping distance when chasing
                
                // Play siren sound if not already playing
                if (sirenAudio != null && !sirenAudio.isPlaying) {
                    sirenAudio.Play();
                }
            
            }
        }
    }

    // Patrol logic
    void Patrol()
    {
        if (agent != null && agent.isOnNavMesh && agent.enabled)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GoToNextPatrolPoint();
            }
        }
        else
        {
            Debug.LogWarning("NavMeshAgent is not on the NavMesh or is not enabled for patrol.");
        }
    }


    // Logic for chasing the player
    void HandleChase() {
        if (CanSeePlayer()) {
            // Player is in sight, continue chasing
            agent.SetDestination(player.position);

            // Check if agent has reached the stopping distance to the player
            if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending) {
                guardRenderer.material.color = Color.red; // Change color to red when catching the player
                Debug.Log("Player caught!");
            }
        } else {
            // Player is out of sight, record the last known position and start searching
            lastKnownPosition = player.position;
            StartSearch(); // Begin search
            guardRenderer.material.color = originalColor; // Revert color when losing sight
        }
    }

    // Logic for the search state
    void HandleSearch() {
        searchTimer += Time.deltaTime;

        // If the player is found during the search
        if (CanSeePlayer()) {
            isSearching = false;
            isChasing = true;
            guardRenderer.material.color = Color.blue; // Change color to blue when chasing again
            
            // Play siren sound if not already playing
            if (sirenAudio != null && !sirenAudio.isPlaying) {
                sirenAudio.Play();
            }
            
            return;
        }

        // If the search time is up, return to patrol
        if (searchTimer >= searchDuration) {
            StopSearch();
            return;
        }

        // Move to predefined search points
        if (!agent.pathPending && agent.remainingDistance < 0.5f) {
            GoToNextSearchPoint();
        }
    }

    // Start searching logic
    void StartSearch() {
        isChasing = false; // Stop chasing state
        isSearching = true; // Enter search state
        searchTimer = 0.0f;

        // Initialize search points around the last known position
        InitializeSearchPoints();

        // Go to the first search point
        currentSearchPointIndex = 0;
        agent.SetDestination(searchPoints[currentSearchPointIndex]);

        // Revert color when entering search state
        guardRenderer.material.color = originalColor;
    }

    // Stop searching logic
    void StopSearch() {
        isSearching = false;
        searchTimer = 0.0f;

        // Return to patrol state
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
    }

    // Initialize search points around the last known position
    void InitializeSearchPoints() {
        searchPoints = new Vector3[4];
        float searchRadius = 1.0f;

        // Initialize four directions for search points
        Vector3[] directions = {
            new Vector3(searchRadius, 0, 0),
            new Vector3(-searchRadius, 0, 0),
            new Vector3(0, 0, searchRadius),
            new Vector3(0, 0, -searchRadius)
        };

        for (int i = 0; i < directions.Length; i++) {
            Vector3 potentialPoint = lastKnownPosition + directions[i];
            NavMeshHit hit;

            // Check if the search point is on a walkable area
            if (NavMesh.SamplePosition(potentialPoint, out hit, 1.0f, NavMesh.AllAreas)) {
                searchPoints[i] = hit.position; // Use the valid position
            } else {
                searchPoints[i] = lastKnownPosition; // Default to the last known position if no valid position is found
            }
        }
    }

    // Move to the next search point
    void GoToNextSearchPoint() {
        currentSearchPointIndex = (currentSearchPointIndex + 1) % searchPoints.Length;
        agent.SetDestination(searchPoints[currentSearchPointIndex]);
    }

    // Determine if the player is in sight
    bool CanSeePlayer() {
        // Calculate direction to the player from the guard
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (angleBetweenGuardAndPlayer < viewAngle / 2) {
            // Check if the player is within the viewing angle
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer <= viewDistance) {
                // Perform a raycast to ensure there are no obstacles between the guard and the player
                RaycastHit hit;
                if (Physics.Raycast(transform.position, directionToPlayer, out hit, viewDistance)) {
                    if (hit.transform == player) {
                        return true; // Player is in sight
                    }
                }
            }
        }
        return false; // Player is not in sight
    }

    // Move to the next patrol point
    void GoToNextPatrolPoint() {
        // Return if no patrol points are set
        if (patrolPoints.Length == 0) return;

        // Update patrol point index to loop through patrol points
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;

        // Set the next patrol point as the destination
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
    }

    // Use Gizmos to visualize patrol points, paths, and field of view in the editor
void OnDrawGizmos() {
    // Visualize patrol points and patrol path
    if (patrolPoints != null && patrolPoints.Length > 0) {
        // Set Gizmos color to green
        Gizmos.color = Color.green;

        // Draw a small sphere at each patrol point
        foreach (Transform patrolPoint in patrolPoints) {
            Gizmos.DrawSphere(patrolPoint.position, 0.02f);
        }

        // Draw lines connecting patrol points
        for (int i = 0; i < patrolPoints.Length; i++) {
            Transform currentPoint = patrolPoints[i];
            Transform nextPoint = patrolPoints[(i + 1) % patrolPoints.Length];
            Gizmos.DrawLine(currentPoint.position, nextPoint.position);
        }
    }

    // Visualize the field of view as a sector
    Gizmos.color = Color.yellow;

    // Draw a fan shape to represent the field of view
    Vector3 startAngle = Quaternion.Euler(0, -viewAngle / 2, 0) * transform.forward;
    Vector3 endAngle = Quaternion.Euler(0, viewAngle / 2, 0) * transform.forward;

    int segmentCount = 20; // Number of segments to approximate the arc
    float angleStep = viewAngle / segmentCount;

    Vector3 previousPoint = transform.position + startAngle * viewDistance;

    for (int i = 1; i <= segmentCount; i++) {
        float currentAngle = -viewAngle / 2 + angleStep * i;
        Vector3 nextPointDirection = Quaternion.Euler(0, currentAngle, 0) * transform.forward;
        Vector3 nextPoint = transform.position + nextPointDirection * viewDistance;

        Gizmos.DrawLine(transform.position, nextPoint); // Draw from center to arc
        Gizmos.DrawLine(previousPoint, nextPoint); // Draw between arc points

        previousPoint = nextPoint;
    }
}

    // Detect entering the trap zone using a direct reference
    private void OnTriggerEnter(Collider other) {
        if (other.transform == trapZone) {
            ParalyzeGuard();
        }
    }

    // Paralyze the guard when entering the trap zone
    void ParalyzeGuard() {
        isParalyzed = true;
        agent.isStopped = true; // Stop the agent
    }
}
