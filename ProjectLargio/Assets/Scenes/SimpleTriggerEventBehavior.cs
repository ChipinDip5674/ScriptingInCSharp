using UnityEngine;
using UnityEngine.Events;

public class SimpleTriggerEventBehaviour : MonoBehaviour
{
    // UnityEvent that can be set up in the Inspector for different actions
    public UnityEvent onPlayerEnter;

    // Reference to the Animator component to trigger animations
    public Animator characterAnimator;

    // This method is triggered when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the player (assuming the player has a "Player" tag)
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the damage zone!");

            // Invoke the UnityEvent to perform any assigned actions
            onPlayerEnter.Invoke();

            // Set the "Hit" trigger on the character's Animator component
            if (characterAnimator != null)
            {
                characterAnimator.SetTrigger("Hit");
            }
            else
            {
                Debug.LogWarning("Animator not assigned in the Inspector!");
            }
        }
    }
}