using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    private float spawnTimer;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if(Time.time > spawnTimer)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawnRate = Random.Range(2.0f, 8.0f);
            spawnTimer = Time.time + spawnRate;
        }
    }
}
