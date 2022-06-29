using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntrl2 : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = UltimateJoystick.GetHorizontalAxis("Movement");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        float verticalMove = UltimateJoystick.GetVerticalAxis("Movement");
        if (isGrounded == true)
         {
             extraJumps = extraJumpsValue;
             if (verticalMove >= .5f && extraJumps > 0)
             {
                 rb.velocity = Vector2.up * jumpForce;
                 extraJumps--;
             }
             else if (verticalMove >= .5f && extraJumps > 0 && isGrounded == true)
             {
                 rb.velocity = Vector2.up * jumpForce;
             }
         }
    }

            
     void Flip()
     {
         facingRight = !facingRight;
         transform.Rotate(0f, 180f, 0f);
     }
    
}
