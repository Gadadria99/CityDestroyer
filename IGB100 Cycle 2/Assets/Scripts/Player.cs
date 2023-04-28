using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float health = 100;
    private float maxHealth;

    //UI Elements
    public Slider healthbar;

	// Use this for initialization
	void Start () {
        maxHealth = health;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void takeDamage(float dmg) {
        health -= dmg;

        healthbar.value = (health / maxHealth);

        if (health <= 0) {
           
            Destroy(this.gameObject);
        }
    }
}
