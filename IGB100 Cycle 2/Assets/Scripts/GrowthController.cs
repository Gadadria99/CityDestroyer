using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthController : MonoBehaviour
{
    public float energyLevel = 50f;
    public float maxEnergy = 100f;
    public GameObject Player;

    //public bool cableFront;
    //new LayerMask WhatCable;
    //private RaycastHit CableHit;
    //public float cableCheckDistance;
    //private Rigidbody rb;
    //public Transform orientation;
    //public KeyCode Energize = KeyCode.R;
    

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        setScale();
         //CheckForCable();
         //Recharge();
        
    }





    private void setScale()
    {
        if (energyLevel <= 0)
        {
            

            Player.transform.localScale = new Vector3(1f, 1f, 1f);
        }



        else if (energyLevel < 80)
        {
            Player.transform.localScale = new Vector3(1f, 1f, 1f);
        }



        else
        {
            if (energyLevel >= 80)
            {
                Player.transform.localScale = new Vector3(35f, 35f, 35f);
            }

        }

    }

    public void Recharge(float chargeRate)
    {
        if (energyLevel < maxEnergy)
            energyLevel += 0.1f;
        else
            energyLevel = maxEnergy;
    }


   // private void Recharge()
   // {
   //     if (cableFront == true)
   //     {
   //         energyLevel = energyLevel * 2;
   //     }
  //  }

  //  private void CheckForCable()
   // {
   //     cableFront = Physics.Raycast(transform.position, orientation.forward, out CableHit, cableCheckDistance, WhatCable);


  //  }



}  
