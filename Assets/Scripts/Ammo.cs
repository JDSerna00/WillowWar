using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        weapon controller = other.GetComponent<weapon>();
        if (controller != null)
        { 
            controller.Shooting();
            Destroy(gameObject);
        }
    }
}
