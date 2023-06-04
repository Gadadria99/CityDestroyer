using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{

    public float BHealth2 = 100.0f;
    public Material[] orb;
    public Material[] points;
    public PlayerPunch pp2;
    private Collider buildingCol;
    Renderer rend;
    private bool dead = false;

    public GameObject fire;
    public GameObject plasma;
    public GameObject cosmic;
    public bool exploded = false;

    public float rotateSpeed;

    public GameObject End;

    private void Start()
    {
        buildingCol = GetComponent<Collider>();
        rend = GetComponent<MeshRenderer>();
        Material[] materials = rend.materials;
        //rend.enabled = true;
        materials[0] = points[0];
        materials[1] = orb[0];
        rend.materials = materials;
    }

    void Update()
    {
        pp2 = PlayerPunch.body;
        transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime);

        if (BHealth2 < 90.0f && BHealth2 >= 70.0f)
        {

            rotateSpeed = 200;
            Material[] materials = rend.materials;
            materials[0] = points[1];
            materials[1] = orb[1];
            rend.materials = materials;
        }
        else if (BHealth2 < 70.0f && BHealth2 >= 50.0f)
        {

            rotateSpeed = 300;
            Material[] materials = rend.materials;
            materials[0] = points[2];
            materials[1] = orb[2];
            rend.materials = materials;
        }
        else if (BHealth2 < 50.0f && BHealth2 >= 30.0f)
        {

            rotateSpeed = 400;
            Material[] materials = rend.materials;
            materials[0] = points[3];
            materials[1] = orb[3];
            rend.materials = materials;
        }
        else if (BHealth2 < 25.0f && BHealth2 > 1.0f)
        {
            rotateSpeed = 550;
        }
        else if (BHealth2 <= 0.0f)
        {
            dead = true;
        }

        if (dead)
        {
            SingletonParams.Instance.currentHealth = 100;
            buildingCol.enabled = false;
            if (exploded == false)
            {
                var f = Instantiate(fire, transform.position, transform.rotation);
                var p = Instantiate(plasma, transform.position, transform.rotation);
                var c = Instantiate(cosmic, transform.position, transform.rotation);
                Destroy(f, 4);
                Destroy(p, 4);
                Destroy(c, 5);
                exploded = true;
            }
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
