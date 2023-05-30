using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : MonoBehaviour
{
    public float rotateSpeed = 50f;
   // public bool bonus = false;
    public float health;
    public PlayerHealth ph;

    // Start is called before the first frame update
    void Start()
    {
        ph = GameObject.FindWithTag("PlayerBody").GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime);
        //if (bonus)
        // {
        //health += 10;
        //bonus = false;

        health = ph.currentHealth;
        // }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && health < 100)
        {
            ph.healthBonus(10);
            //if(TryGetComponent(out PlayerHealth playerHealth))
            //{

            //}

            Debug.Log("!! - ITEM GET - !!");
            Destroy(this.gameObject);

            //bonus = true;


        }
    }
}
