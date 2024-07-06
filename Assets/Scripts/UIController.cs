using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    public static UIController instance;

    public UnityEngine.UI.Image[] heartContainer;
    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;

    public Text txtLives;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthUI(int health, int maxHealth)
    {
        
        if(maxHealth > heartContainer.Length * 2)
        {
            maxHealth = heartContainer.Length * 2;
        }
        for (int i = 0; i < heartContainer.Length; i++)
        {
            heartContainer[i].enabled = false;
            if (i +1 <= ((maxHealth+1) / 2))
            {
                heartContainer[i].enabled = true;
                if ((i+1) * 2 <= health)
                {
                    heartContainer[i].sprite = heartFull;
                } else if (i * 2 + 1 == health)
                {
                    heartContainer[i].sprite = heartHalf;
                }
                else
                {
                    heartContainer[i].sprite = heartEmpty;
                }
            }
           
        }
        
    }

    public void UpdateLivesUI(int lives)
    {

    }
}
