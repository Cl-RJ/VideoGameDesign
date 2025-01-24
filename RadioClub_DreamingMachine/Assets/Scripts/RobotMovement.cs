using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 80f; // Separate variable for rotation speed
    public float floatUpSpeed = 2f;
    private Animator animator;
    private Rigidbody rb;
    private bool canMove = false;
    private bool isFloatingUp = false;
    private Vector3 rotation = Vector3.zero;
    private PlayerInventory inventory;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        inventory = GetComponent<PlayerInventory>();
        rotation = transform.eulerAngles;

        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.drag = 1f;
    }

    void Update()
    {
        if (!canMove && animator.GetCurrentAnimatorStateInfo(0).IsName("Leg Spawn"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                animator.SetBool("legsSpawned", true);
                canMove = true;
            }
        }

        if (canMove)
        {
            if (isFloatingUp)
            {
                FloatUpwards();
            }
            else
            {
                HandleMovement();
            }
        }
    }

    void HandleMovement()
    {
        float moveVertical = Input.GetAxis("Vertical");

        // Use rotationSpeed for turning instead of moveSpeed
        if (Input.GetKey(KeyCode.A))
        {
            rotation[1] -= rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotation[1] += rotationSpeed * Time.deltaTime;
        }

        transform.eulerAngles = rotation;

        if (moveVertical != 0)
        {
            Vector3 moveDirection = transform.forward * moveVertical * moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + moveDirection);

            if (moveVertical > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("WalkSpeed", 1f);
            }
            else if (moveVertical < 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("WalkSpeed", -1f);
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
            animator.SetFloat("WalkSpeed", 0f);
        }
    }

    void FloatUpwards()
    {
        Vector3 floatDirection = Vector3.up * floatUpSpeed * Time.deltaTime;
        transform.position += floatDirection;

        animator.SetBool("isMoving", true);
        animator.SetFloat("WalkSpeed", 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (inventory.CanClimb && collision.collider.CompareTag("Metallic"))
        {
            isFloatingUp = true;
            rb.isKinematic = true; // Set kinematic to avoid physics forces
            rb.useGravity = false; // Disable gravity for stability
            Debug.Log("Started Floating Up");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Metallic"))
        {
            isFloatingUp = false;
            rb.isKinematic = false; // Restore Rigidbody to non-kinematic
            rb.useGravity = true;   // Re-enable gravity
            Debug.Log("Stopped Floating Up");
            animator.SetBool("isMoving", false);
            animator.SetFloat("WalkSpeed", 0f);
        }
    }
}