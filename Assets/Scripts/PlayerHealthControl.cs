using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthControl : MonoBehaviour
{
    public static PlayerHealthControl Instance;

    public int maxHealth = 6;
    public int currentHealth;

    public float invincibleTime = 2f;
    private float invincibleCounter = 0;


    private void Awake()
    {
        Instance = this;
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
            invincibleCounter = invincibleTime;
            PlayerController.instance.anim.SetTrigger("hurt");
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                gameObject.SetActive(false);
            }
        }
        
        UIController.instance.UpdateHealthUI(currentHealth, maxHealth);
    }
}
