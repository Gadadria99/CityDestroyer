using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 1.0f;
    public float bulletSpeed = 10.0f;
    public float shootDistance = 10.0f; // Distance at which the enemy will start shooting

    private GameObject target;
    private float fireTimer;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (target != null)
        {
            // Calculate the distance between the enemy and the player
            float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);

            // Check if the enemy is within the shooting distance
            if (distanceToPlayer <= shootDistance)
            {
                // Check if enough time has passed since the last shot
                if (Time.time >= fireTimer + 1.0f / fireRate)
                {
                    // Set the fire timer to the current time
                    fireTimer = Time.time;

                    // Spawn a new bullet prefab at the bullet spawn point
                    GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

                    // Calculate the direction vector from the enemy to the player and set the bullet's velocity
                    Vector3 direction = target.transform.position - transform.position;
                    bullet.GetComponent<Rigidbody>().velocity = direction.normalized * bulletSpeed;

                    //Destroy the bullet a second after it is projected
                    Destroy(bullet, 1f);
                }
            }
        }
    }
}