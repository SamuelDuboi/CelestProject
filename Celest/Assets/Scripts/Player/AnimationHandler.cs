using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class AnimationHandler : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   public void Run()
    {
        animator.SetBool("isGrounded", true);
        animator.SetBool("IsRunning", true);
    }
    public void Walk()
    {
        animator.SetBool("isGrounded", true);
        animator.SetBool("IsRunning", false);
    }
    public void Dash()
    {
        animator.SetBool("isGrounded", false);
        animator.SetTrigger("Dash");
    }
    public void Fall()
    {
        animator.SetBool("isGrounded", false);
        animator.SetTrigger("Fall");
    }
    public void TouchGround()
    {
        animator.SetBool("isGrounded", true);
    }
    public void Jump()
    {
        animator.SetTrigger("Jump");
    }
    public void Hit(bool isDead)
    {
        animator.SetTrigger("Hit");
        if(isDead)
            animator.SetTrigger("Death");
    }

}
