using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    
    Rigidbody2D rigidbody2D;
    public int HitPoints;
    public int MaxHitPoints = 30;
    public HealthBarBehaviour HealthBar;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        HitPoints = MaxHitPoints;
        HealthBar.SetHealth(HitPoints, MaxHitPoints);
    }

    public void TakeDamage (int damage)
    {
        HitPoints -= damage;
        HealthBar.SetHealth(HitPoints, MaxHitPoints);

        if (HitPoints <= 0)
        {
            Die();
        }
    }
     void OnCollisionEnter2D(Collision2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.ChangeHealth(1);
        }
    }

    void Die ()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameWin");
    }
}
