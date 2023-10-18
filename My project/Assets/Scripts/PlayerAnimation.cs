using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private bool isMoving;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();  
    }
    private void Update()
    {
        isMoving = IsPlayerMoving();

        animator.SetBool("isWalking", !isMoving);
        animator.SetBool("isWalking", isMoving);
    }

    bool IsPlayerMoving()
    {
        return rb.velocity.magnitude > 0.5f;
    }
}
