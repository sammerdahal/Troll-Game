using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScriptJ : MonoBehaviour
{
    public float jumpForce = 10f; // Force applied for the spike's jump
    private Rigidbody2D rb;
    private bool isGrounded; // To check if the spike is on the ground
    public GameObject startPoint; // The starting position of the player
    public GameObject player; // Reference to the player GameObject

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is missing on the spike object.");
        }

        if (startPoint == null || player == null)
        {
            Debug.LogError("Please assign the StartPoint and Player objects in the inspector.");
        }
    }

    void Update()
    {
        // Check for space key press to make the spike jump if grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Reset vertical velocity
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // Prevent further jumping until grounded again
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            // Allow jumping again when the spike touches the ground
            isGrounded = true;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            // Reset player's position to the starting point
            if (startPoint != null && player != null)
            {
                player.transform.position = startPoint.transform.position;
            }

            // Reset gravity to normal if it was inverted
            GravitySwitchPlayer playerScript = other.gameObject.GetComponent<GravitySwitchPlayer>();
            if (playerScript != null)
            {
                playerScript.ResetGravity();
            }
        }
    }
}
