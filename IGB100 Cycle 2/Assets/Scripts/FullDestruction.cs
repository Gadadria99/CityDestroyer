using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullDestruction : MonoBehaviour
{
    public float BHealth = 99.0f;
    public GameObject[] building;
    public PlayerPunch pp;

    void Update() 
    {
        pp = PlayerPunch.body;

        if(BHealth < 99.0f && BHealth >= 66.0f)
        {
            building[0].SetActive(false);
            building[1].SetActive(true);          
        }
        else if (BHealth < 66.0f && BHealth >= 33.0f)
        {
            building[1].SetActive(false);
            building[2].SetActive(true);
        }
        else if (BHealth < 33.0f)
        {
            building[2].SetActive(false);
            building[3].SetActive(true);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fist" /*&& pp.isAttking*/)
        {
            BHealth -= 33.0f;
            Debug.Log("Health is: " + BHealth);
        }
    }
}
