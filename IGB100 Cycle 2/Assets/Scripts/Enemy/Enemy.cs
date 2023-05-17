using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    NavMeshAgent agent;
    public GameObject target;
    public GameObject deathEffect;
    public float moveSpeed = 15.0f;
    public float health = 100.0f;
    public float damageAmount = 10f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        try
        {
            target = (GameObject.FindGameObjectWithTag("Player"));
            
        }
        catch
        {
            target = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    //Enemy movement - beeline to player if mouse is rightclicked
    private void Movement()
    {
        if (target)
        {
            // Calculate the direction vector from the enemy to the player
            Vector3 direction = target.transform.position - transform.position;
            direction.y = 0f; // ignore any vertical difference

            // The desired distance to keep from the player
            float keepDistance = 5f;

            // Calculate the current distance from the player
            float currentDistance = direction.magnitude;

            // If the current distance is less than the desired distance, move away from the player and keep the same distance
            if (currentDistance < keepDistance)
            {
                agent.destination = transform.position - direction.normalized * (keepDistance - currentDistance);
            }
            // Otherwise, move towards the player
            else
            {
                agent.destination = target.transform.position;
            }
        }
    }


    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }

}
