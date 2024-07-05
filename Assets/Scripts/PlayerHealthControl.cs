using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthControl : MonoBehaviour
{
    public static PlayerHealthControl instance;

    public int maxHealth = 6;
    public int currentHealth;

    public float invincibleTime = 2f;
    private float invincibleCounter = 0;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        UIController.instance.UpdateHealthUI(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
        }
        
    }

    public void HurtPlayer(int dmg)
    {
        if(invincibleCounter <= 0)
        {
            currentHealth -= dmg;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                gameObject.SetActive(false);
            } else
            {
                invincibleCounter = invincibleTime;
                PlayerController.instance.KnockBack();
            }
            
        }
        
        UIController.instance.UpdateHealthUI(currentHealth, maxHealth);
    }

    public void HealPlayer(int amount, bool full)
    {
        if (full)
        {
            currentHealth = maxHealth;
        } else
        {
            currentHealth += amount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
        
        UIController.instance.UpdateHealthUI(currentHealth, maxHealth);
    }
    
}
