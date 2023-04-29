using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    NavMeshAgent agent;
    public GameObject target;

    public float moveSpeed = 15.0f;
    public float moveSpeed2 = 0.2f;
    public float health = 100.0f;

    public float damage = 1f;
    private float damageRate = 0.2f;
    private float damageTime;

    public GameObject deathEffect;
    
 




    // Start is called before the first frame update
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();

        //Player reference exception catching

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


        if(target)
        {
            agent.destination = target.transform.position;
        }



    }

    




    public  void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Player" && Time.time > damageTime)
        {
            other.transform.GetComponent<Player>().takeDamage(damage);
            damageTime = Time.time + damageRate;

        }
    }

}
