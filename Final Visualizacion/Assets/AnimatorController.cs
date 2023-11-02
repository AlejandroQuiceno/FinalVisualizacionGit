using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator animator;
    public string animationName = "YourAnimationName";
    public float scrollSpeedMultiplier;

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.95)
        {
            
        }
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float speedMultiplier = scrollInput * scrollSpeedMultiplier;

        speedMultiplier = Mathf.Clamp(speedMultiplier, -1.0f, 1.0f);

        animator.SetFloat("SpeedMultiplier", speedMultiplier*100);
    }
}
