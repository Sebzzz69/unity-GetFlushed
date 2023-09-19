using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5.0f; // Adjust the speed as needed
    public float damping = 5.0f; // Adjust the damping factor as needed

    private Vector2 velocity;

    [SerializeField] private KeyCode keyUp;
    [SerializeField] private KeyCode keyLeft;
    [SerializeField] private KeyCode keyDown;
    [SerializeField] private KeyCode keyRight;

    float horizontalInput;
    float verticalInput;

    bool isCollidingWithWall;

    private void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput).normalized;


        // Calculate velocity based on input and speed 
        velocity = movementDirection * speed;
        

        // Move the character
        this.transform.position = (Vector2)transform.position + velocity * Time.deltaTime;

        horizontalInput = 0;
        verticalInput = 0;



    }

    void CheckInput()
    {
        if (Input.GetKey(keyUp))
        {
            verticalInput = 1;
        }
        else if (Input.GetKey(keyDown))
        {
            verticalInput = -1;
        }

        if (Input.GetKey(keyRight))
        {
            horizontalInput = 1;
        }
        else if (Input.GetKey(keyLeft))
        {
            horizontalInput = -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.GetComponent<TeleportObject>().Teleport();
        }
        else
        {
            isCollidingWithWall = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isCollidingWithWall = false;
    }



}
