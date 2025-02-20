using System;
using UnityEngine;

public class FlappyRectangle : MonoBehaviour
{
    public float jumpForce = 5f; // The force applied when jumping
    public float forwardSpeed = 2f; // Speed to move forward when pressing D
    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to the rectangle
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the player presses the Space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Apply an upward force to the rectangle
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Check if the player presses the D key
        if (Input.GetKey(KeyCode.D))
        {
            // Move the rectangle forward
            rb.linearVelocity = new Vector2(forwardSpeed, rb.linearVelocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Handle collision with ground or obstacles
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            // You can add game over logic here
        }
    }
}
