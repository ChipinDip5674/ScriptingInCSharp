using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Character movement speed
    public float jumpForce = 10f; // Character jump force
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private bool isGrounded; // Is the character on the ground?
    private bool facingRight = true; // Track which direction the character is facing

    void Start()
    {
        // Get the Rigidbody2D component attached to the GameObject
        rb = GetComponent<Rigidbody2D>();

        // Ensure character starts grounded
        isGrounded = true;
    }

    void Update()
    {
        // Get input for horizontal movement (A/D or Left/Right arrow keys)
        float moveInput = Input.GetAxis("Horizontal");

        // Move the character
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Check for jump input and if the character is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply jump force
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false; // Mark the character as no longer grounded
        }

        // Flip the character if moving in the opposite direction
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }
    }

    // Detect collision with the ground to reset grounded state
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Character is grounded when it touches the ground
        }
    }

    // Flip the character's direction
    private void Flip()
    {
        facingRight = !facingRight; // Invert the current direction
        Vector3 scaler = transform.localScale; // Get the local scale of the character
        scaler.x *= -1; // Flip the x scale to turn the character
        transform.localScale = scaler; // Apply the flipped scale
    }
}