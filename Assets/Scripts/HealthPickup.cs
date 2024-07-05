using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public bool fullHealth = false;
    public int healAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(PlayerHealthControl.instance.currentHealth >= PlayerHealthControl.instance.maxHealth)
            {
                return;
            } else
            {
               PlayerHealthControl.instance.HealPlayer(healAmount, fullHealth);
               Destroy(gameObject);
            }
        }
    }
}
