using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class AnimationHandler : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        EventHandler.instance.OnTakeDamage += () => Hit(false);
        EventHandler.instance.OnDeath += () => Hit(true);
    }
    public void Flip(bool left)
    {
        spriteRenderer.flipX = left;
    }
   public void Run()
    {
        animator.SetBool("IsRunning", true);
    }
    public void Idle()
    {
        animator.SetBool("IsRunning", false);
    }
    public void Dash()
    {
        animator.SetBool("IsGrounded", false);
        animator.SetTrigger("Dash");
    }
    public void Fall()
    {
        animator.SetBool("IsGrounded", false);
        animator.SetTrigger("Fall");
    }
    public void TouchGround()
    {
        animator.SetBool("IsGrounded", true);
    }
    public void Jump()
    {
        animator.SetTrigger("Jump");
        animator.SetBool("IsGrounded", false);
    }

    public void Hit(bool isDead)
    {
        animator.SetTrigger("Hit");
        if(isDead)
            animator.SetTrigger("Death");
    }
    public void Revive()
    {
        animator.SetBool("Death", false);
    }

}
