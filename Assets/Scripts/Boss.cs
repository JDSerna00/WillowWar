using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public int bossHealth = 10;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.ChangeHealth(1);
        }
    }
    public void TakeDamage (int damage)
    {
        bossHealth -= damage;

        if (bossHealth <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
    }
}
