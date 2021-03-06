using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
   private GameObject currentTeleporter;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
    {
        if (currentTeleporter == null)

        {
            currentTeleporter = collision.gameObject;
            transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
            Destroy(collision.gameObject);
        }
    }
    
    }

private void OnTriggerExit2D(Collider2D collision)
    {
    if (collision.CompareTag("Teleporter"))
    {
        if (collision.gameObject != currentTeleporter)
        {
            currentTeleporter = null;
        }
    }
    
    }
}
