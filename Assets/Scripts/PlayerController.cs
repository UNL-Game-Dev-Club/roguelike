using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    private bool isGrounded;

    public Transform top_left;
    public Transform bottom_right;
    public LayerMask ground_layers;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0f);
        transform.Translate(movement * speed);

        float jump = Input.GetAxisRaw("Jump");
        isGrounded = Physics2D.OverlapArea(top_left.position, bottom_right.position, ground_layers);

        if (jump == 1f && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpHeight));
        }
    }
}