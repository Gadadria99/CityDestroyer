using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
   // public float energy;
    //public GrowthController script;
    public TMPro.TextMeshProUGUI nrg;
    public float energyLevel;
    public float maxEnergy = 100f;
    public float rechargedValue;
    public bool Grow;



    void Update()
    {
        rechargedValue = GameObject.FindWithTag("Player").GetComponent<GrowthController>().eRfwd;
        Grow = GameObject.FindWithTag("Player").GetComponent<GrowthController>().Grow;



        if (energyLevel < 0)
        {
            energyLevel = 0;
            

        }
        else if (energyLevel > maxEnergy)
        {
            energyLevel = maxEnergy;
        }

        else
        {
            if (rechargedValue >= energyLevel)
            {
                energyLevel = rechargedValue;
            }
        }
        recharged();

       // recharged();


        //else if (gc < 0)
        //{
        //    gc = 0;

        //}
        //else if (gc > 100)
        //{
        //    gc = 100;
        //}

        

        ////energy = script.energyLevel;
        //energy = GameObject.FindWithTag("Player").GetComponent<GrowthController>().energyLevel;
        nrg.text = "Energy: " + energyLevel.ToString("F0");
    }

    public void energyDrain(float nrgVal)
    {
        if (energyLevel >=0)
        {
            energyLevel -= (nrgVal * Time.deltaTime);
        }
        
    }


    private void recharged()
    {
        if (rechargedValue < 0)
        {
            rechargedValue = 0;


        }
        else if (rechargedValue > maxEnergy)
        {
            rechargedValue = maxEnergy;
        }

        //else if (Grow == true)
        //{
        //    rechargedValue = 0;
        //}
        else
        {
            if (rechargedValue >= energyLevel)
            {
                energyLevel = rechargedValue;
            }
        }
    }
}