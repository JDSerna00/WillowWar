using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public GameObject proyectilPrefab;
    public float speed = 3.0f;
    public float jumpForce = 1.0f;
    public int lives = 3;
    public int totalLives;
    public int maxHealth = 3;
    public int health { get { return currentHealth; }}
    public int currentHealth;
    public float timeInvincible = 2.0f;
    public bool isInvincible;
    float invincibleTimer;
    int shoots;
    bool isGrounded;
    bool m_FacingRight = true;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        totalLives = lives;
        shoots = 10;
    }
    void Update()
    {
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
        
        if(Input.GetKey(KeyCode.Space) && isGrounded)
            Jump();

        animator.SetBool("run", horizontal != 0);    

         if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        if (Input.GetKey(KeyCode.C))
        {
            if (shoots > 0)
            {
            
            }
        }
    }

    void Jump()
    {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
            isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        isGrounded = true;
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

    public void MaxHealth()
    {
        maxHealth = maxHealth + 1;
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
        currentHealth = Mathf.Clamp(currentHealth + amount , 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

}
