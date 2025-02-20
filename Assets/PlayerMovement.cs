using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float sprintMultiplier = 1.5f;
    private float move;

    public float jump;

    public bool isJumping;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal input
        move = Input.GetAxis("Horizontal");

        // Check if sprinting
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? speed * sprintMultiplier : speed;

        // Apply movement
        rb.linearVelocity = new Vector2(currentSpeed * move, rb.linearVelocity.y);

        // Handle jumping
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jump));
            Debug.Log("jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}