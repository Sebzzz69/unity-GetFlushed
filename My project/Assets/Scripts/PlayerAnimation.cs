using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private bool isMoving;
    private bool isPushing;

    private PushPlayer pushPlayer;


    private void Awake()
    {
        pushPlayer = GetComponent<PushPlayer>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();  
    }
    private void Update()
    {
        isMoving = IsPlayerMoving();
        isPushing = IsPlayerPushing();

        animator.SetBool("isWalking", !isMoving);
        animator.SetBool("isWalking", isMoving);

        animator.SetBool("isPushing", !isPushing);
        animator.SetBool("isPushing", isPushing);
    }

    bool IsPlayerMoving()
    {
        return rb.velocity.magnitude > 0.5f;
    }

    bool IsPlayerPushing()
    {
        if (Input.GetKey(pushPlayer.pushKey))
        {
            return true;
        }

        return false;
    }
}
