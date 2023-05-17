using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public float BHealth = 100.0f;
    public GameObject Building;
    public PlayerPunch pp;

    void Update()
    {
        pp = PlayerPunch.body;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fist" && pp.isAttking)
        {
            if (BHealth == 100)
            {
                BHealth -= 50.0f;
                Building.transform.localScale = new Vector3(0.6f, 0.9f, 0.6f);
                Debug.Log("Health is: " + BHealth);
            }
            else if (BHealth == 50.0f)
            {
                BHealth = 0.0f;
                Destroy(Building);
            }
        }
    }
}