using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealth : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Player controller = other.GetComponent<Player>();
        if (controller != null)
        { 
            controller.MaxHealth();
            FindObjectOfType<AudioManager>().Play("PickUp");    
            Destroy(gameObject);
        }
    }
}
