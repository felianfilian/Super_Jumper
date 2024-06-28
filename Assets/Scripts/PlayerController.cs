using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Transform groundCheckPoint;

    public bool isGrounded = true;
    public float moveSpeed = 8;
    public float jumpForce = 20;
  
    private Rigidbody2D rb;

    private bool canDoubleJump = false;
    private float runModificator = 1f;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    

    void Update()
    {
        Move();
        Run(1.7f);
        Jump();
    }

    public void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * moveSpeed * runModificator;
        rb.velocity = new Vector2(moveX, rb.velocity.y);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isGrounded = false;
                canDoubleJump = true;
            } else if (canDoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                canDoubleJump = false;
            }


        }
    }

    public void Run(float modificator)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            runModificator = modificator;
        }
        else
        {
            runModificator = 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded=true;
        }
    }
}
