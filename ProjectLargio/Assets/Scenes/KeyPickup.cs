using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private bool isPickedUp = false; // Tracks if the key is picked up
    private Transform player; // Reference to the player

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isPickedUp) return; // Prevent multiple pickups

        if (other.CompareTag("Player")) // Ensure only the player can pick up the key
        {
            isPickedUp = true;
            player = other.transform; // Store the player's transform
            transform.SetParent(player); // Parent the key to the player
            transform.localPosition = new Vector3(0, 1, 0); // Adjust position relative to the player
        }
    }

    private void Update()
    {
        if (isPickedUp && Input.GetKeyDown(KeyCode.J)) // Check if J is pressed
        {
            DropKey();
        }
    }

    private void DropKey()
    {
        isPickedUp = false; // Mark the key as not picked up
        transform.SetParent(null); // Unparent the key
        player = null; // Clear the player reference
        transform.position += new Vector3(0, -0.5f, 0); // Adjust position slightly to avoid overlap
    }
}