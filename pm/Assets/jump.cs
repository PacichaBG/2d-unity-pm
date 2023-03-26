using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int jumpPower;
    [SerializeField] float fallMultiplier;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    Vector2 vecGravity;

    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 0.12f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
    }
}
