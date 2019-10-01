using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Transform groundCheck;

    public Rigidbody2D rb;
    public Vector2 movement;
    public float movementSpeed = 20f;
    public float jumpForce = 50f;
    private bool jump = false;
    private bool touchingGround = false;
    public LayerMask groundLayer;


    // Update is called once per frame
    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump")) {
            jump = true;
            
        }

    }

    void FixedUpdate() {
        touchingGround = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, .01f, groundLayer);

        if (colliders.Length > 0) {
            touchingGround = true;
        }

        if(touchingGround) {
            rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        }

        if(touchingGround && jump) {
            touchingGround = false;
            rb.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }
}
