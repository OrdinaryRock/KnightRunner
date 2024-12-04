using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefabs;

    [SerializeField]
    private float minSpawnDelay = 1.5f;
    [SerializeField]
    private float maxSpawnDelay = 3f;

    public void Start()
    {
        InvokeSpawnEnemy();
    }

    private void InvokeSpawnEnemy()
    {

        float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        Invoke(nameof(SpawnEnemy), spawnDelay);
    }

    private void SpawnEnemy()
    {

        Vector2 spawnOffset = new Vector2();
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        Instantiate(enemyPrefabs[enemyIndex], (Vector2) transform.position + spawnOffset, transform.rotation);

        InvokeSpawnEnemy();
    }
}
