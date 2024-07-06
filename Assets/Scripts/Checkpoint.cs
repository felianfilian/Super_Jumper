using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private Animator anim;

    private bool isActive = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !isActive)
        {
            CheckpointController.instance.DeactivateCheckpoints();
            isActive = true;
            anim.SetBool("active", true);
        }
    }

    public void DeactivateCheckpoint()
    {
        
        isActive = false;
        anim.SetBool("active", false);
    }
}
