using UnityEngine;

public class BananaCollectible : MonoBehaviour
{
    public int points = 5; // Points awarded for collecting this banana
    private Animator animator; // Reference to the Animator component
    private bool isCollected = false; // To prevent multiple triggers

    private void Start()
    {
        // Get the Animator component attached to the banana
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component is missing on the Banana!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            isCollected = true; // Mark the banana as collected to prevent multiple triggers

            // Trigger the "isCollected" animation
            if (animator != null)
            {
                animator.SetTrigger("isCollected");
            }

            // Add points to the player's score
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.AddScore(points);
            }

            // Destroy the banana after the animation finishes
            Destroy(gameObject, 0.5f); // Adjust the delay to match the animation length
        }
    }
}