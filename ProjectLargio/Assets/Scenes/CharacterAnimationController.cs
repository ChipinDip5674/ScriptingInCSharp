using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;

    // Event function
    private void Start()
    {
        // Cache the Animator component attached to CharacterArt
        animator = GetComponent<Animator>();
    }

    // Event function
    private void Update()
    {
        HandleAnimations();
    }

    // Frequently called
    private void HandleAnimations()
    {
        // Handle running and idling
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetTrigger(name: "Run");
        }
        else
        {
            animator.SetTrigger(name: "Idle");
        }

        // Handle jumping
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger(name: "Jump");
        }

        // Handle wall jumping
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger(name: "WallJump");
        }
    }
}