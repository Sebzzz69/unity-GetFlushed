using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5.0f; // Adjust the speed as needed
    public float damping = 5.0f; // Adjust the damping factor as needed

    private Vector2 velocity;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Calculate velocity based on input and speed
        velocity = movementDirection * speed;

        // Move the character
        Vector2 newPosition = (Vector2)transform.position + velocity * Time.deltaTime;
        transform.position = newPosition;

        // Apply damping to gradually stop the character
        velocity = Vector2.Lerp(velocity, Vector2.zero, damping * Time.deltaTime);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.GetComponent<TeleportObject>().Teleport();
        }
        
    }
    
        
    
}
