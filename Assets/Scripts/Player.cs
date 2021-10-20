using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    private int extraJumps;
    public float speed = 3.0f;
    public float jumpForce = 1.0f;
    public int maxHealth = 3;
    public int health = 3;
    [SerializeField] healthSystem hs;
    public int currentHealth;
    public int extraJumpsValue;
    public float timeInvincible = 2.0f;
    public float checkRadius;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public bool isInvincible;
    float invincibleTimer;
    
    bool isGrounded;
    bool m_FacingRight = true;
    Animator animator;

    void Start()
    {
        extraJumps = extraJumpsValue;
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        hs.DrawHearts(health, maxHealth);
    }
    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        float horizontal = Input.GetAxis("Horizontal");
        rigidbody2d.velocity = new Vector2(horizontal * speed, rigidbody2d.velocity.y);

        if (horizontal > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (horizontal < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}

             animator.SetBool("run", horizontal != 0);  
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;  
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            Jump();  
            extraJumps--;
        }            
            else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
            {
                Jump();
            }  

         if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }                
    }
        
    void Jump()
    {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
            FindObjectOfType<AudioManager>().Play("Jump");
    }

    void Flip()
    {
        m_FacingRight = !m_FacingRight;

		transform.Rotate(0f, 180f, 0f);
    }

    public void SpeedBoost()
    {
        speed = speed*1.2f;
    }

    public void doubleJump()
    {
        extraJumpsValue = extraJumpsValue + 1;
    }
    public void MaxHealth()
    {
        maxHealth = maxHealth + 1;
        hs.DrawHearts(health,maxHealth);
    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        if (health > 0)
        health -= amount;
        FindObjectOfType<AudioManager>().Play("TakeDamage");
        hs.DrawHearts(health,maxHealth);

        if (health <= 0)
        {
            
            SceneManager.LoadScene("GameOver");            
        }
    }
    public void HealPlayer(int dmg)
    {
        if (health < maxHealth)
        {
        health += dmg;
        hs.DrawHearts(health,maxHealth);
        }
    }
    
 }


