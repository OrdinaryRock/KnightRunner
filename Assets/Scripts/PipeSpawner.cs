using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pipePrefabs;

    [SerializeField]
    private float minSpawnDelay = 1.5f;
    [SerializeField]
    private float maxSpawnDelay = 3f;
    
    [SerializeField]
    private float verticalSpawnRange = 2f;

    public void Activate()
    {
        InvokeSpawnPipe();
    }

    private void InvokeSpawnPipe()
    {
        float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        Invoke(nameof(SpawnPipe), spawnDelay);
    }

    private void SpawnPipe()
    {
        Vector2 spawnOffset = new Vector2();
        spawnOffset.y = Random.Range(verticalSpawnRange, -verticalSpawnRange);
        int pipeIndex = Random.Range(0, pipePrefabs.Length);

        Instantiate(pipePrefabs[pipeIndex], (Vector2) transform.position + spawnOffset, transform.rotation);

        InvokeSpawnPipe();
    }
}
