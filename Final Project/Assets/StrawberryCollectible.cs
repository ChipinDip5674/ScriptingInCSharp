using UnityEngine;

public class StrawberryCollectible : MonoBehaviour
{
    public int points = 1; // Points awarded for collecting this item
    private Animator animator; // Reference to the Animator component
    private AudioSource audioSource; // Reference to the AudioSource component
    private bool isCollected = false; // To prevent multiple triggers
    private float destroyTime = 0.4f; // Maximum time before the object is destroyed

    private void Start()
    {
        // Get the Animator component attached to the strawberry
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component is missing on the Strawberry!");
        }

        // Get the AudioSource component attached to the strawberry
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on the Strawberry!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            isCollected = true; // Mark the strawberry as collected to prevent multiple triggers

            // Trigger the "isCollected" animation
            if (animator != null)
            {
                animator.SetTrigger("isCollected");
            }

            // Play the sound effect
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // Add points to the player's score
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.AddScore(points);
            }

            // Destroy the object after the shorter of destroyTime or audio clip length
            float timeToDestroy = Mathf.Min(audioSource != null ? audioSource.clip.length : destroyTime, destroyTime);
            Destroy(gameObject, timeToDestroy);
        }
    }
}