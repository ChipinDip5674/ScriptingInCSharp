using UnityEngine;

public class FrogAnimatorController : MonoBehaviour
{
    public Transform parentObject; // Reference to the parent (movement object)
    private Animator animator; // Reference to the Animator component
    private Rigidbody2D parentRb; // Reference to the Rigidbody2D on the parent
    private bool canMove = true; // Flag to control whether the frog can move

    void Start()
    {
        // Get the Animator component on this child object
        animator = GetComponent<Animator>();

        // Ensure the parentObject is assigned
        if (parentObject == null)
        {
            Debug.LogError("Parent object is not assigned! Please assign it in the Inspector.");
            return;
        }

        // Get the Rigidbody2D from the parent object
        parentRb = parentObject.GetComponent<Rigidbody2D>();

        if (parentRb == null)
        {
            Debug.LogError("Rigidbody2D component is missing on the parent object!");
        }
    }

    void Update()
    {
        if (parentRb != null && animator != null)
        {
            if (canMove)
            {
                // Check if the parent object is moving to the right
                bool isMovingRight = parentRb.velocity.x > 0;

                // Set the "isRunning" parameter in the Animator
                animator.SetBool("isRunning", isMovingRight);

                // Set the "isIdle" parameter to false if moving
                animator.SetBool("isIdle", !isMovingRight);
            }
            else
            {
                // If movement is disabled, ensure "isIdle" is true and "isRunning" is false
                animator.SetBool("isIdle", true);
                animator.SetBool("isRunning", false);
            }
        }
    }

    // Method to stop the frog's animations and switch to Idle
    public void StopAnimations()
    {
        canMove = false; // Disable movement
    }
}