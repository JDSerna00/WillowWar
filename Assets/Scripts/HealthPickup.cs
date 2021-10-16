using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Player controller = other.GetComponent<Player>();

        if (controller != null)
        {
            if(controller.currentHealth  < controller.maxHealth)
            {
                controller.HealPlayer(1);
                Destroy(gameObject);
            }
            
        }
    }
}
