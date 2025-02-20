using UnityEngine;

public class PlayerMovementG : MonoBehaviour
{
    public float speed = 5f;          // Horizontal speed
    public float jumpForce = 8f;      // Jump force (lowered to feel more natural)
    public bool isJumping = false;    // Track if the player is in the air
    public float gravityScale = 2f;   // Adjust gravity scale for realistic jumps

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;  // Set the custom gravity scale
    }

    void Update()
    {
        // Geometry Dash-like horizontal movement
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);  // Always move at constant speed

        // Handle jumping
        if (Input.GetButtonDown("Jump") && !isJumping)  // Only jump if not already in the air
        {
            Jump();
        }
    }

    void Jump()
    {
        // Apply an instant jump force in the Y-axis
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Maintain current horizontal velocity and apply jump force
        isJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Detect when the player hits the ground
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false; // Allow jumping again when touching the ground
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        // If leaving the ground, stop jumping
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
