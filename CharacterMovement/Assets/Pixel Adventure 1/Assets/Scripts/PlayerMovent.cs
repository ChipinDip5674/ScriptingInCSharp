using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = .05f; // Speed of the player movement
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal input (A/D or Left/Right arrow keys)
        float moveX = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(moveX, 0f).normalized; // Only move horizontally
    }

    void FixedUpdate()
    {
        // Move the player with a Rigidbody2D for physics interaction
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }
}