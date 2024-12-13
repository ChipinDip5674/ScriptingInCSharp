using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop the frog's movement
            FrogController frogController = other.GetComponent<FrogController>();
            if (frogController != null)
            {
                frogController.StopMovement();
            }

            // Trigger the end game sequence
            gameManager.EndGame();
        }
    }
}