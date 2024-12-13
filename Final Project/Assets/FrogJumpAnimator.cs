using UnityEngine;

public class FrogJumpAnimator : MonoBehaviour
{
    public Transform parentObject; // Reference to the parent object with Rigidbody2D
    public LayerMask groundLayer; // Layer mask to define what is "ground"
    public Transform groundCheckPoint; // A point for checking ground contact
    public float groundCheckRadius = 0.1f; // Radius for the ground check

    private Animator animator; // Reference to the Animator on this object
    private bool isGrounded; // Is the frog on the ground?

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();

        // Ensure the parent object and ground check point are assigned
        if (parentObject == null)
        {
            Debug.LogError("Parent object is not assigned! Please assign it in the Inspector.");
            return;
        }
        if (groundCheckPoint == null)
        {
            Debug.LogError("Ground Check Point is not assigned! Please assign it in the Inspector.");
        }
    }

    void Update()
    {
        // Check if the frog is on the ground using OverlapCircle
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        // Update the Animator's "isJumping" parameter
        if (animator != null)
        {
            animator.SetBool("isJumping", !isGrounded);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the ground check radius in the Editor
        if (groundCheckPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
        }
    }
}