using UnityEngine;

public class Walk : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;  // Adjust the jump force as needed
    public bool isGrounded = false;  // To check if the character is grounded

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to the GameObject
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from the arrow keys (horizontal and vertical axes)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Create a new movement vector
        Vector3 movement = new Vector3(moveX, 0f, moveY);

        // Apply movement to the GameObject
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Check for jump input and if the character is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply jump force
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // Check if the character is on the ground using collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}