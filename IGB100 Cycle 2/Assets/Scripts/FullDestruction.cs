using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullDestruction : MonoBehaviour
{
    public float BHealth2 = 99.0f;
    public GameObject[] buildinglist;
    public PlayerPunch pp2;
    private Collider buildingCol;
    public bool building1 = true;
    public bool building2 = false;
    public bool building3 = false;
    public bool building4 = false;

    private float flip;
    private float chance;
    public GameObject HP;
    public GameObject NRG;

    private void Start()
    {
        buildingCol = GetComponent<Collider>();
    }

    void Update()
    {
        pp2 = PlayerPunch.body;
        chance = Random.Range(0, 11);
        flip = Random.Range(0, 2);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fist" && building1 && pp2.isAttking)
        {
            BHealth2 -= 33.0f;
            if (BHealth2 < 99.0f && BHealth2 >= 66.0f)
            {
                Debug.Log("Health is: " + BHealth2);
                building1 = false;
                building2 = true;
                buildinglist[0].SetActive(false);
                buildinglist[1].SetActive(true);
            }
        }
        else if (other.tag == "Fist" && building2 && pp2.isAttking)
        {
            BHealth2 -= 33.0f;
            if (BHealth2 < 66.0f && BHealth2 >= 33.0f)
            {
                Debug.Log("Health is: " + BHealth2);
                building2 = false;
                building3 = true;
                buildinglist[1].SetActive(false);
                buildinglist[2].SetActive(true);
            }
        }
        else if (other.tag == "Fist" && building3 && pp2.isAttking)
        {
            BHealth2 -= 33.0f;
            buildingCol.enabled = false;
            if (BHealth2 < 33.0f)
            {
                Debug.Log("Health is: " + BHealth2);
                building3 = false;
                building4 = true;
                buildinglist[2].SetActive(false);
                buildinglist[3].SetActive(true);

                if (chance <= 3)
                {
                    if (flip == 0)
                    {
                        Instantiate(HP, new Vector3(transform.position.x, 32, transform.position.z), transform.rotation);
                    }
                    else if (flip == 1) 
                    {
                        Instantiate(NRG, new Vector3(transform.position.x, 32, transform.position.z), transform.rotation);
                    }
                }
            }
        }
    }
}
