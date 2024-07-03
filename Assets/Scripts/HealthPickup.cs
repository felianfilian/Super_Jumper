using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(PlayerHealthControl.Instance.currentHealth >= PlayerHealthControl.Instance.maxHealth)
            {
                return;
            } else
            {
                PlayerHealthControl.Instance.HealPlayer(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
