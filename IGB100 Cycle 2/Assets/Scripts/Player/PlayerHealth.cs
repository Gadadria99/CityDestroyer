using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour 
{

    public float maxHealth = 100f;
    private float currentHealth;

    //UI Elements
    //public Slider healthbar;
    //public Text healthText;
    public TMPro.TextMeshProUGUI hp;
    public GameObject deathMessageUI;

    private void Start () 
    {
        currentHealth = maxHealth;
        UpdateHealthText();
        deathMessageUI.SetActive(false);
    }

    private void Update()
    {
        UpdateHealthText();
    }

    public void TakeDamage(float dmg) 
    {
        currentHealth -= dmg;

        //healthbar.value = (currentHealth / maxHealth);

        if (currentHealth <= 0f) 
        {
            currentHealth = 0f;
            Destroy(this.gameObject);
            PlayerDeath();
        }
    }

    private void UpdateHealthText()
    {
        // Update the UI Text element with the current health value
        if (hp.text != null)
        {
            hp.text = "Health: " + currentHealth.ToString("F0");
        }
    }

    private void PlayerDeath()
    {
        deathMessageUI.SetActive(true);
    }
}
