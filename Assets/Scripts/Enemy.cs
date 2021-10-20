using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public int health = 2;
    public GameObject Drop;
    public Transform transform;
    
    // Start is called before the first frame update
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
        health -= damage;

        if (health <= 0)
        {
            Die();
            DropHealth();
        }
    }

    void Die ()
    {
        FindObjectOfType<AudioManager>().Play("Death");
        Destroy(gameObject);
    }
    void DropHealth()
    {
        Vector2 position = transform.position;
        GameObject matica = Instantiate(Drop, position, Quaternion.identity);
        matica.SetActive(true);
    }
}
