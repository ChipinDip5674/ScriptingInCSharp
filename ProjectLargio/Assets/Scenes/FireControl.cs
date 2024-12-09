using UnityEngine;

public class FireController : MonoBehaviour
{
    private Animator animator;
    private Collider2D fireCollider;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        fireCollider = GetComponent<Collider2D>();
    }

    public void TurnOffFire()
    {
        if (animator != null)
        {
            animator.SetTrigger("Deactivate"); // Use a trigger to transition animations
        }

        if (fireCollider != null)
        {
            fireCollider.enabled = false; // Disable the fire collider
        }

        Debug.Log("Fire turned off!");
    }
}