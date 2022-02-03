using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StrawBerryMovement : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Collect()
    {
        animator.SetTrigger("Collect");
    }
    public void Collected()
    {
        Destroy(gameObject);
    }
}
