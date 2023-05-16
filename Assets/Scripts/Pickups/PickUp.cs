using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Variables

    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<PlayerController>();
            ActivatePickUp();
            Destroy(gameObject);
        }
    }

    public virtual void ActivatePickUp()
    {
        // Insert pickup stuff here
    }
}
