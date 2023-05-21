using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public float energy;
    //public GrowthController script;
    public TMPro.TextMeshProUGUI nrg;


    void Update()
    {
        //energy = script.energyLevel;
        energy = GameObject.FindWithTag("Player").GetComponent<GrowthController>().energyLevel;
        nrg.text = "Energy: " + energy.ToString("F0");
    }
}