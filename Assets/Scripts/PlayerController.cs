using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8;
    public float jumpForce = 20;

    private float runModificator = 1f;
    private Rigidbody2D rb;


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
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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
}
