using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public float health;
    public float energy;
    public GrowthController script;
    public TMPro.TextMeshProUGUI nrg;

    // Start is called before the first frame update
    void Start()
    {
        health = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        energy = script.energyLevel;
        nrg.text = "Energy: " + energy.ToString("F0");
    }
}