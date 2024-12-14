using UnityEngine;

public class PineappleCollectible : MonoBehaviour
{
    public int points = 20; // Points awarded for collecting this pineapple
    private Animator animator; // Reference to the Animator component
    private AudioSource audioSource; // Reference to the AudioSource component
    private bool isCollected = false; // To prevent multiple triggers
    private float destroyTime = 0.5f; // Maximum time before the object is destroyed

    private void Start()
    {
        // Get the Animator component attached to the pineapple
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component is missing on the Pineapple!");
        }

        // Get the AudioSource component attached to the pineapple
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on the Pineapple!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            isCollected = true; // Mark the pineapple as collected to prevent multiple triggers

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