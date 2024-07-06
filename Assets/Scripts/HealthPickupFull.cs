using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupFull : MonoBehaviour
{
    public GameObject healthPickupEffectGold;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(PlayerHealthControl.instance.currentHealth >= PlayerHealthControl.instance.maxHealth)
            {
                return;
            } else
            {
               PlayerHealthControl.instance.HealPlayerFull();
               Instantiate(healthPickupEffectGold, transform.position, Quaternion.identity);
               Destroy(gameObject);
            }
        }
    }
}
