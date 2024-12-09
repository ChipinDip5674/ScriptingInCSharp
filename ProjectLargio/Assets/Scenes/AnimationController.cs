using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetActiveState(bool isActive)
    {
        if (animator != null)
        {
            animator.SetBool("isActive", isActive);
        }
    }
}