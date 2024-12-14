using UnityEngine;

public class StopMovementTrigger : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager
    private Animator cupAnimator; // Reference to the cup's Animator

    void Start()
    {
        // Get the Animator component on this GameObject (the cup)
        cupAnimator = GetComponent<Animator>();
        if (cupAnimator == null)
        {
            Debug.LogError("Animator component is missing from the Cup GameObject!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop the player's movement
            FrogController frogController = other.GetComponent<FrogController>();
            if (frogController != null)
            {
                frogController.StopMovement();
            }

            // Stop the player's animations
            FrogAnimatorController animatorController = other.GetComponentInChildren<FrogAnimatorController>();
            if (animatorController != null)
            {
                animatorController.StopAnimations();
            }

            // Trigger the cup's animation
            if (cupAnimator != null)
            {
                cupAnimator.SetTrigger("Collect");
            }

            // Trigger the end game sequence
            gameManager.EndGame();
        }
    }
}