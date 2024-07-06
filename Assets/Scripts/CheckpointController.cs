using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;
    public Checkpoint[] checkpoints;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        checkpoints = FindObjectsByType<Checkpoint>(FindObjectsSortMode.None);
    }

    public void DeactivateCheckpoints()
    {
        foreach (Checkpoint checkpoint in checkpoints)
        {
            checkpoint.DeactivateCheckpoint();
        }
    }
}
