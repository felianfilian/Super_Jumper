using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [HideInInspector]
    public Animator anim;

    [Header("Objects")]
    public Transform groundCheckPoint;
    public SpriteRenderer spriteRenderer;

    [Header("Variables")]
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
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    

    void Update()
    {
        Move();
        Run(1.7f);
        Jump();
        FlipPlayer();
        AnimatePlayer();
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

    public void FlipPlayer()
    {
        if(rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        } else if(rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void AnimatePlayer()
    {
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("ySpeed", rb.velocity.y);
        anim.SetBool("doubleJump", !canDoubleJump);
        if (runModificator > 1f)
        {
            anim.SetBool("run", true);
        } else
        {
            anim.SetBool("run", false);
        }
        
    }

    public void KnockBack()
    {
        rb.velocity = new Vector2(0f, jumpForce * 0.5f);
        anim.SetTrigger("hurt");
    }
}
