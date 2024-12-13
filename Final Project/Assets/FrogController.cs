using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the frog's rightward movement
    public float jumpForce = 10f; // Force applied to jump
    private Rigidbody2D rb; // Reference to the Rigidbody2D
    private bool isGrounded = true; // Check if the frog is on the ground
    private bool canMove = true; // Flag to control if the frog can move

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing from the Frog GameObject!");
        }
    }

    void Update()
    {
        if (canMove)
        {
            // Use the updated moveSpeed value to move the frog to the right
            Vector2 currentVelocity = rb.velocity;
            currentVelocity.x = moveSpeed;
            rb.velocity = currentVelocity;

            // Jump when Space is pressed and frog is grounded
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isGrounded = false; // Set grounded to false after jumping
            }
        }
        else
        {
            // Stop all horizontal movement
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the frog lands on something tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Method to stop the frog's movement
    public void StopMovement()
    {
        canMove = false; // Disable movement
    }
}