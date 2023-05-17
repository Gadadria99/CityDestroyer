using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    private float spawnTimer;
    public float spawnRate = 3.0f;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.time < GameManager.instance.maxTime && Time.time > spawnTimer)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawnTimer = Time.time + spawnRate;
        }
       
    }


}
