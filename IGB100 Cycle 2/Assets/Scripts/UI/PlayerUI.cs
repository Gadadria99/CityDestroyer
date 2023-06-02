using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    public TMPro.TextMeshProUGUI nrg;
    public float energyLevel;
    public float currentHealth;

    void Update()
    {
        
        energyLevel = SingletonParams.Instance.energyLevel; 
        nrg.text = energyLevel.ToString("F0") + "%";
        
    }

}