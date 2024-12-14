using UnityEngine;

public class LoseGameTrigger : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Trigger the "isHit" animation
            FrogAnimatorController animatorController = other.GetComponentInChildren<FrogAnimatorController>();
            if (animatorController != null)
            {
                animatorController.TriggerHit();
            }

            // Stop the player's movement
            FrogController frogController = other.GetComponent<FrogController>();
            if (frogController != null)
            {
                frogController.StopMovement();
            }

            // Trigger the "You Lose" end game state
            gameManager.LoseGame();
        }
    }
}