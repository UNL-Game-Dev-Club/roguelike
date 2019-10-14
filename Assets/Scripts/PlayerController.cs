using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variable declarations
    public float speed;

    public float jumpHeight;
    public Vector2 counterJumpForce;
    private float jumpForce;
    private bool isGrounded;
    //private bool isJumping;
    private bool jumpKeyHeld;

    public Transform bottomLeft;
    public Transform bottomRight;
    public LayerMask groundLayers;

    private Rigidbody2D rb;

    //Called when the object this is attached to is loaded
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        jumpForce = CalculateJumpForce(Physics2D.gravity.magnitude, jumpHeight);
    }

    //Called once per frame
    void Update()
    {
        
    }

    //Called once per physics update, 50 times per second by default (independent of framerate)
    //Anything that relates to physics should go here
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0f);
        transform.Translate(movement * speed);

        HandleJumping();
    }

    //Calculates force that should be applied given a strength of gravity and desired jump height
    public static float CalculateJumpForce(float gravityStrength, float jumpHeight)
    {
        //h = v^2/2g
        //2gh = v^2
        //sqrt(2gh) = v
        return Mathf.Sqrt(2 * gravityStrength * jumpHeight);
    }

    //Handles jumping mechanics, including logic and applying forces
    private void HandleJumping()
    {
        RaycastHit2D leftRaycast = Physics2D.Raycast(bottomLeft.transform.position, Vector2.down, 0.1f, groundLayers);
        RaycastHit2D rightRaycast = Physics2D.Raycast(bottomRight.transform.position, Vector2.down, 0.1f, groundLayers);

        if (leftRaycast.collider != null || rightRaycast.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //TODO: Work out physics quirks

        if ((Input.GetAxisRaw("Jump") == 1f && isGrounded) && rb.velocity.y <= 0f)
        {
            jumpKeyHeld = true;
            rb.AddForce(Vector2.up * jumpForce * rb.mass, ForceMode2D.Impulse);
        }
        else if (Input.GetAxisRaw("Jump") == 0f)
        {
            jumpKeyHeld = false;
        }

        if (true) //Can be altered to include isJumping in the future if needed
        {
            if (!jumpKeyHeld && Vector2.Dot(rb.velocity, Vector2.up) > 0)
            {
                rb.AddForce(counterJumpForce * rb.mass);
            }
        }
    }
}