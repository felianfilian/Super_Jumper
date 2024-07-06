using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public Rigidbody2D rb;

    [Header("Objects")]
    public SpriteRenderer spriteRenderer;

    [Header("Variables")]
    
    public float moveSpeed = 8;
    public float jumpForce = 20;
    public float knockBackTime = 0.5f;
    public float knockBackSpeed = 5;

    [Header("Ground Check")]
    public Transform groundCheckPoint;
    public float groundcheckRadius = 0.2f;
    public LayerMask whatIsGround;

    [HideInInspector] public bool isGrounded = true;
    private bool characterControl;
    private bool canDoubleJump = false;
    private float runModificator = 1f;
    private float knockBackCounter;

    private void Awake()
    {
        characterControl = true;
        instance = this;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    

    void Update()
    {
        isGrounded = GroundCheck();
        if (characterControl)
        {
            Move();
            Run(1.7f);
            Jump();
            FlipPlayer();
            AnimatePlayer();
        }

        if(knockBackCounter > 0)
        {
            rb.velocity = new Vector2(knockBackSpeed * -transform.localScale.x, rb.velocity.y);
            knockBackCounter -= Time.deltaTime;
            characterControl = false;
        } else
        {
            characterControl= true;
        }
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

    public bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, groundcheckRadius, whatIsGround);
    }

    public void FlipPlayer()
    {
        if(rb.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
        } else if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
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
        rb.velocity = new Vector2(0, jumpForce * 0.5f);
        anim.SetTrigger("hurt");
        knockBackCounter = knockBackTime;
    }
}
