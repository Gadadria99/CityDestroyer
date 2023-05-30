using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{    

    public float BHealth2 = 100.0f;
    public Material[] material;
    public PlayerPunch pp2;
    private Collider buildingCol;
    Renderer rend;
    private bool dead = false;

    public float rotateSpeed;

    private void Start()
    {
        buildingCol = GetComponent<Collider>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    void Update()
    {
        pp2 = PlayerPunch.body;
        transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime);

        if (BHealth2 < 90.0f && BHealth2 >= 70.0f)
        {

            rend.sharedMaterial = material[1];
        }
        else if (BHealth2 < 70.0f && BHealth2 >= 50.0f)
        {

            rend.sharedMaterial = material[2];
        }
        else if (BHealth2 < 50.0f && BHealth2 >= 30.0f)
        {

            rend.sharedMaterial = material[3];
        }
        else if (BHealth2 <= 0.0f)
        {
            dead = true;
        }

        if (dead)
        {
            buildingCol.enabled = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fist"))
        {
            if (pp2.isAttking)
            {
                BHealth2 -= 10.0f;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Laser")
        {
            BHealth2 -= 0.2f;
        }
    }

}
