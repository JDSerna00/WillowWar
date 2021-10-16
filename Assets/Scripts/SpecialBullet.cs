using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 2;
    public Rigidbody2D rb;
    float destroyTime = 0.5f;
    
    void Start()
    {
        rb.velocity = transform.right * speed;
    }


   void OnCollisionEnter2D(Collision2D other)
    {
        Enemy e = other.collider.GetComponent<Enemy>();
        if (e != null)
        {
           e.TakeDamage(damage);
        }
        Boss ex = other.collider.GetComponent<Boss>();
        if (ex != null)
        {
           ex.TakeDamage(damage);
        }
        Enemy2 e2 = other.collider.GetComponent<Enemy2>();
        if (e2 != null)
        {
           e2.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
    void Update()
    {
        destroyTime -= Time.deltaTime;
        if(transform.position.magnitude > 1000.0f || destroyTime  <= 0)
        {
            Destroy(gameObject);
        }
    }

        
    }


