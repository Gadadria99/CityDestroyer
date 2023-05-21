using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : MonoBehaviour
{
    public float rotateSpeed = 50f;
    public bool bonus = false;
    private float health;
    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime);
        if (bonus)
        {
            health += 10;
            bonus = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && health < 100)
        {
            Destroy(this);
            bonus = true;
            Debug.Log("!! - ITEM GET - !!");
        }
    }
}
