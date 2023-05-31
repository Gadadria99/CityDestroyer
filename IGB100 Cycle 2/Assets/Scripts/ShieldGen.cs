using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGen : MonoBehaviour
{
    public float BHealth2 = 99.0f;
    public GameObject[] buildinglist;
    public GameObject plasma;
    public PlayerPunch pp2;
    private Collider buildingCol;
    public bool building1 = true;
    public bool building2 = false;
    public bool building3 = false;
    public bool building4 = false;
    public bool building5 = false;
    public bool shieldDead = false;
    private bool exploded = false;


    private void Start()
    {
        buildingCol = GetComponent<Collider>();
    }

    void Update()
    {
        pp2 = PlayerPunch.body;


        if (BHealth2 < 80.0f && BHealth2 >= 60.0f)
        {

            building1 = false;
            building2 = true;
            buildinglist[0].SetActive(false);
            buildinglist[1].SetActive(true);
        }
        else if (BHealth2 < 60.0f && BHealth2 >= 40.0f)
        {

            building2 = false;
            building3 = true;
            buildinglist[1].SetActive(false);
            buildinglist[2].SetActive(true);
        }
        else if (BHealth2 < 40.0f && BHealth2 >= 20.0f)
        {
            building3 = false;
            building4 = true;
            buildinglist[2].SetActive(false);
            buildinglist[3].SetActive(true);
        }
        else if (BHealth2 < 20.0f)
        {
            building4 = false;
            building5 = true;
            buildinglist[3].SetActive(false);
            buildinglist[4].SetActive(true);
            shieldDead = true;
            
            if (shieldDead)
            {
                buildingCol.enabled = false;
                if (exploded == false)
                {
                    var p = Instantiate(plasma, transform.position, transform.rotation);
                    Destroy(p, 4);
                    exploded = true;
                }
            }
        }
    }

    public void TakeDamage(float dmg)
    {
        BHealth2 -= dmg;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fist" && building1 && pp2.isAttking)
        {
            BHealth2 -= 5.0f;
        }
        else if (other.tag == "Fist" && building2 && pp2.isAttking)
        {
            BHealth2 -= 5.0f;
        }
        else if (other.tag == "Fist" && building3 && pp2.isAttking)
        {
            BHealth2 -= 5.0f;
        }
        else if (other.tag == "Fist" && building4 && pp2.isAttking)
        {
            BHealth2 -= 5.0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Laser" && building1)
        {
            BHealth2 -= 0.2f;
        }
        else if (other.tag == "Laser" && building2)
        {
            BHealth2 -= 0.2f;
        }
        else if (other.tag == "Laser" && building3)
        {
            BHealth2 -= 0.2f;
        }
        else if (other.tag == "Laser" && building4)
        {
            BHealth2 -= 0.2f;
        }
    }
}
