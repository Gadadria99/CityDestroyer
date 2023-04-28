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

    public float damage = 25.0f;
    private float damageRate = 0.2f;
    private float damageTime;

    public GameObject deathEffect;
    
    // float RightclickActive = 12;
    // float RightclickThreshold = 12;
    //public Vector3 PlayerLocation;





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

       // if (GameManager.instance.player && (RightclickActive < 12))
        //{
            // transform.LookAt(GameManager.instance.player.transform.position);
            //transform.position += transform.forward * moveSpeed * Time.deltaTime;

            //get the Input from Horizontal axis


            
           // PlayerLocation = (GameObject.FindGameObjectsWithTag("Player")[0].transform.position);
           
            
        //}
        
       // checkRightClick();
        Movement();
    }






   // void checkRightClick()
   // {
   //     if (Input.GetKey(KeyCode.Mouse1))
    //    {
    //        RightclickActive = 0;
    //        RightclickActive += Time.deltaTime;
    //    }
   //     else
    //    {
    //        RightclickActive += Time.deltaTime;
   //     }
            

   // }










    //Enemy movement - beeline to player if mouse is rightclicked

    private void Movement()
    {


        if(target)
        {
            agent.destination = target.transform.position;
        }

       // if (GameManager.instance.player && (RightclickActive < 12))
       // {
            // transform.LookAt(GameManager.instance.player.transform.position);
            //transform.position += transform.forward * moveSpeed * Time.deltaTime;

            //get the Input from Horizontal axis
            
        //    Translate();
            
            //get the Input from Vertical axis
            //float verticalInput = Input.GetAxis("Vertical");
            
      //  }
       // else
            
            // alter for 3d level//
        //    transform.position += transform.forward * moveSpeed * Time.deltaTime;
            


    }

    

   // private void Translate()
   // {
   //     float dist = Vector3.Distance(PlayerLocation, transform.position);
   //     transform.position += (PlayerLocation - transform.position) * (moveSpeed2 / (dist / 10)) * Time.deltaTime;
   // }




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
