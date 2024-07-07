using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float respawnTime = 2f;
    

    private void Awake()
    {
        instance = this;
    }

    public void RespawnPlayer(bool liveLost)
    {
        PlayerController.instance.rb.velocity = Vector2.zero;
        if(liveLost)
        {
            PlayerHealthControl.instance.DecreaseLives(1);
        }
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnTime);
        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerHealthControl.instance.HealPlayerFull();
        
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        UIController.instance.gameOverScreen.SetActive(true);
    }
}
