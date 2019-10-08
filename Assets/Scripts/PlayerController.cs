using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public float jumpHeight;
    public Vector2 counterJumpForce;
    private float jumpForce;
    private bool isGrounded;
    private bool isJumping;
    private bool jumpKeyHeld;

    public Transform topLeft;
    public Transform bottomRight;
    public LayerMask groundLayers;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        jumpForce = CalculateJumpForce(Physics2D.gravity.magnitude, jumpHeight);
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0f);
        transform.Translate(movement * speed);

        isGrounded = Physics2D.OverlapArea(topLeft.position, bottomRight.position, groundLayers);
        if (Input.GetAxisRaw("Jump") == 1f && isGrounded)
        {
            jumpKeyHeld = true;
            rb.AddForce(Vector2.up * jumpForce * rb.mass, ForceMode2D.Impulse);
        }
        else if (Input.GetAxisRaw("Jump") == 0f)
        {
            jumpKeyHeld = false;
        }

        if (isJumping)
        {
            if (!jumpKeyHeld && Vector2.Dot(rb.velocity, Vector2.up) > 0)
            {
                //TODO: Figure out why this isn't working
                rb.AddForce(counterJumpForce * rb.mass);
            }
        }
    }

    public static float CalculateJumpForce(float gravityStrength, float jumpHeight)
    {
        //h = v^2/2g
        //2gh = v^2
        //sqrt(2gh) = v
        return Mathf.Sqrt(2 * gravityStrength * jumpHeight);
    }
}