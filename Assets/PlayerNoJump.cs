using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    public float sprintMultiplier = 1.5f;
    private float move;

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
    }
}
