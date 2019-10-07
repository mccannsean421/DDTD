using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Transform groundCheck;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;

    public Rigidbody2D rb;
    public Vector2 movement;
    public float movementSpeed = 20f;
    public float jumpForce = 50f;
    private bool jump = false;
    private bool touchingGround = false;
    public LayerMask groundLayer;
    public bool airControl = false;
    private Vector3 m_Velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;

        }

    }

    void FixedUpdate()
    {
        touchingGround = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, .01f, groundLayer);

        if (colliders.Length > 0)
        {
            touchingGround = true;
        }

        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(movement.x * 10f, rb.velocity.y); //replaced move variable

        // And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        // The player can only jump while touching the ground
        if (touchingGround && jump)
        {
            touchingGround = false;
            rb.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }
}
