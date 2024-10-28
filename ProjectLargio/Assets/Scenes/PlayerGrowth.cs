using UnityEngine;

public class PlayerGrowth : MonoBehaviour
{
    // Function to increase the player's scale by 10%
    public void GrowPlayer()
    {
        // Increase the scale by 10%
        transform.localScale *= 1.1f;
    }
}