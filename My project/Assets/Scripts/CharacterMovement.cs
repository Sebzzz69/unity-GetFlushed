using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;            // Adjust the movement speed in the Inspector.
    [SerializeField] float jumpForce = 10f;           // Adjust the jump force in the Inspector.
    float horizontalInput;

    float groundCheckRadius = 0.2f; // Radius of the ground check circle.
    [SerializeField] LayerMask groundLayer;           // Layer mask to determine what is considered ground.

    private Rigidbody2D rigidbody2d;
    private bool isGrounded;
    private bool isFacingRight;
    private bool isJumping;

    private Vector2 movement;

    [SerializeField] Transform groundCheckPosition;
    [SerializeField] int playerNumber = 1; // Set this to 1 or 2 for each player.




    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        isFacingRight = true;
    }

    void Update()
    {
        // Check if the player is grounded.
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundLayer);

        GetInput();
        HandleMovement();
        HandleJump();


        // Check which direction player is facing
        if ((horizontalInput > 0 && !isFacingRight) || (horizontalInput < 0 && isFacingRight))
        {
            FlipCharacter();
        }

        



    }


    void GetInput()
    {
        horizontalInput = Input.GetAxis("HorizontalPlayer" + playerNumber);
        isJumping = Input.GetButtonDown("PlayerJump" + playerNumber);
    }

    void HandleMovement()
    {
        Vector2 movement = new Vector2(horizontalInput, 0) * moveSpeed;
        rigidbody2d.velocity = new Vector2(movement.x, rigidbody2d.velocity.y);
    }
    
    void HandleJump()
    {
        if (isGrounded && isJumping)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
        }
    }

    void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        Debug.Log(scale);

    }

}








