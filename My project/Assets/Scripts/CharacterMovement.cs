using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;            // Adjust the movement speed in the Inspector.
    public float jumpForce = 10f;           // Adjust the jump force in the Inspector.
    public float groundCheckRadius = 0.2f; // Radius of the ground check circle.
    public LayerMask groundLayer;           // Layer mask to determine what is considered ground.

    private Rigidbody2D rb;
    private bool isGrounded;

    public Transform groundCheckPosition;
    public int playerNumber = 1; // Set this to 1 or 2 for each player.

    int horizontalInput;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    void Update()
    {
        // Check if the player is grounded.
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundLayer);


        // Get input from the player.
        float horizontalInput = Input.GetAxis("HorizontalPlayer" + playerNumber);

        // Get input for jumping.
        bool jumpInput = Input.GetButtonDown("PlayerJump" + playerNumber);

        // Calculate the movement vector.
        Vector2 movement = new Vector2(horizontalInput, 0) * moveSpeed;

        // Apply the movement to the Rigidbody2D.
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

        // Handle jumping.
        if (isGrounded && jumpInput)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        //Debug.Log(isGrounded);

        Debug.Log("Horizontal Input: " + horizontalInput);

    }

}








