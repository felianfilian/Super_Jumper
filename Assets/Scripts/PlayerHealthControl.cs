using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthControl : MonoBehaviour
{
    public int maxHealth = 5;

    private int curretnHealth;

    void Start()
    {
        curretnHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hurtPlayer(int dmg)
    {
        curretnHealth -= dmg;
        if (curretnHealth <= 0)
        {
            curretnHealth = 0;
            Debug.Log("dead");
        }
    }
}
