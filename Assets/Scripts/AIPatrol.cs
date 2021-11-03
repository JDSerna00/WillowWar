using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;
    bool isGrounded;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float walkSpeed;
    public float jumpRate = 0.5f;
    private float nextJump = 0.0f;
    public float jumpForce;
    
    
    void Start()
    {
        mustPatrol = true;
    }

    
    void Update()
    {   
        if (mustPatrol)
        {
            Patrol();           
        }
    }

    private void FixedUpdate()
    {
        

        if (Time.time > nextJump)
        {
            mustTurn = false;
            nextJump = Time.time + jumpRate;
            Jump();
            mustTurn = true;
        }
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        }
    }

    void Patrol ()
    {
        if (mustTurn && isGrounded)
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }
    void Flip()
    {
        mustPatrol = false;
        transform.Rotate(0f, 180f, 0f);
        walkSpeed *= -1;
        mustPatrol = true;
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

}
