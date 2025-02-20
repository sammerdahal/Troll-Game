using System;
using UnityEngine;

public class GravitySwitchPlayer : MonoBehaviour
{
    public float speed;
    public float sprintMultiplier = 1.5f;
    private float move;

    public float jump;
    public bool isJumping;

    private Rigidbody2D rb;
    private bool isGravityInverted = false;

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
            rb.AddForce(new Vector2(rb.linearVelocity.x, isGravityInverted ? -jump : jump));
            Debug.Log("jump");
        }

        // Handle gravity inversion
        if (Input.GetKeyDown(KeyCode.W) && !isJumping) // Prevent switching gravity in mid-air
        {
            isGravityInverted = !isGravityInverted;
            rb.gravityScale = isGravityInverted ? -Mathf.Abs(rb.gravityScale) : Mathf.Abs(rb.gravityScale); // Ensure gravity switches faster
            Debug.Log("Gravity switched");
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

    public void ResetGravity()
    {
        if (isGravityInverted)
        {
            isGravityInverted = false;
            rb.gravityScale = Mathf.Abs(rb.gravityScale); // Reset gravity to normal
        }
    }
}
