using System;
using UnityEngine;

public class ReverseMovementScript : MonoBehaviour
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
        // Get horizontal input and reverse the direction
        move = Input.GetAxis("Horizontal") * -1;

        // Check if sprinting with Space
        float currentSpeed = Input.GetKey(KeyCode.Space) ? speed * sprintMultiplier : speed;

        // Apply movement
        rb.linearVelocity = new Vector2(currentSpeed * move, rb.linearVelocity.y);

        // Handle jumping with "S"
        if (Input.GetKeyDown(KeyCode.S) && !isJumping)
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
