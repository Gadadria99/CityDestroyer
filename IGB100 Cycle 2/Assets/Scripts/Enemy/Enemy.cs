using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    NavMeshAgent agent;
    public GameObject target;
    public GameObject deathEffect;
    public float moveSpeed = 60.0f;
    public float health = 100.0f;
    public float damageAmount = 10f;
    bool exploded;
    public PlayerPunch pp;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //try
        //{
        //    target = (GameObject.FindGameObjectWithTag("Player"));
            
        //}
        //catch
        //{
        //    target = null;
        //}
    }

    //void FIxedUpdate()
    //{

    //}


    // Update is called once per frame
    void Update()
    {
        
        try
        {
            target = (GameObject.FindGameObjectWithTag("PBody"));

        }
        catch
        {
            target = null;
        }

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
            float keepDistance = 17f;

            // Calculate the current distance from the player
            float currentDistance = direction.magnitude;

            // If the current distance is less than the desired distance, move away from the player and keep the same distance
            if (currentDistance < keepDistance)
            {
                agent.destination = transform.position - (direction.normalized * 10) * (keepDistance - currentDistance);
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

        if (health <= 0 && exploded == false)
        {

            Destroy(this.gameObject);
            var p = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(p, 4);
            exploded = true;
            
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fist"))
        {
            //PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            //if (playerHealth != null)
            //{
            //    playerHealth.TakeDamage(damageAmount);
            //}

            TakeDamage(50);
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Laser"))
        {
            health -= (100f * Time.deltaTime);
            if (health <= 0 && exploded == false)
            {

                Destroy(this.gameObject);
                var p = Instantiate(deathEffect, transform.position, transform.rotation);
                Destroy(p, 4);
                exploded = true;


            }
        }
    }

}
