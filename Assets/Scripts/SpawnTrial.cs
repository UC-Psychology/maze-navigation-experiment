using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class SpawnTrial : MonoBehaviour
{
    public void trialSpawner(Session session)
    {
        // Generate a new block
        Block block = session.CreateBlock();

        // Generate a new trial in that block
        Trial trial = block.CreateTrial();

        trial.Begin();

        Debug.Log("Spawned trial");
    }
}
