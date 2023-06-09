using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 10;
    public float initialSpawnInterval = 35f;
    public float spawnIntervalDecreaseRate = 1f;
    public float minSpawnInterval = 3f;
    public ShieldGen ShieldScript;

    private int currentEnemies = 0;
    private float spawnInterval;
    private float timer = 0f;

    private void Start()
    {
        spawnInterval = initialSpawnInterval;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (currentEnemies < maxEnemies && timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }

        else if(currentEnemies < maxEnemies && timer >= spawnInterval && ShieldScript.shieldDead == true)
        {
            SpawnEnemy();
            SpawnEnemy();
            timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        // Instantiate the enemy prefab at the spawner's position
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        currentEnemies++;

        // Decrease the spawn interval gradually
        spawnInterval -= spawnIntervalDecreaseRate;
        spawnInterval = Mathf.Max(spawnInterval, minSpawnInterval);
    }


}
