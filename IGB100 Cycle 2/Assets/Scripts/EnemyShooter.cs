using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 1.0f;
    public float bulletSpeed = 10.0f;

    private float fireTimer;

    void Update()
    {
        // Check if the target (player) exists and if enough time has passed since the last shot
        if (GetComponent<Enemy>().target && Time.time >= fireTimer + 1.0f / fireRate)
        {
            // Set the fire timer to the current time
            fireTimer = Time.time;

            // Spawn a new bullet prefab at the bullet spawn point
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

            // Calculate the direction vector from the enemy to the player and set the bullet's velocity
            Vector3 direction = GetComponent<Enemy>().target.transform.position - transform.position;
            bullet.GetComponent<Rigidbody>().velocity = direction.normalized * bulletSpeed;
        }
    }
}