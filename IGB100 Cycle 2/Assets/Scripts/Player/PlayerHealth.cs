using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{


    public TMPro.TextMeshProUGUI hp;
    public float currentHealth;

    void Update()
    {

        currentHealth = SingletonParams.Instance.currentHealth;

        hp.text = "Health: " + currentHealth.ToString("F0");


    }

}