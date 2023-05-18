using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullDestruction : MonoBehaviour
{
    public float BHealth2 = 99.0f;
    public GameObject[] buildinglist;
    public PlayerPunch pp2;
    public bool building1 = true;
    public bool building2 = false;
    public bool building3 = false;
    public bool building4 = false;


    void Update()
    {
        pp2 = PlayerPunch.body;

        //Destroy();


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
            if (BHealth2 < 33.0f)
            {
                Debug.Log("Health is: " + BHealth2);
                building3 = false;
                building4 = true;
                buildinglist[2].SetActive(false);
                buildinglist[3].SetActive(true);
            }
        }
    }


    private void Destroy()
    {
        if (building1 /*&& (BHealth2 < 99.0f && BHealth2 >= 66.0f*/)
        {
            building1 = false;
            building2 = true;
            buildinglist[0].SetActive(false);
            buildinglist[1].SetActive(true);
        }
        //else if (building2 && (BHealth2 < 66.0f && BHealth2 >= 33.0f))
        //{
        //    building2 = false;
        //    building3 = true;
        //    buildinglist[1].SetActive(false);
        //    buildinglist[2].SetActive(true);
        //}
        //else
        //{
        //    if (building3 && BHealth2 < 33.0f)
        //    {
        //        building3 = false;
        //        building4 = true;
        //        buildinglist[2].SetActive(false);
        //        buildinglist[3].SetActive(true);
        //    }
        //}
    }
}
