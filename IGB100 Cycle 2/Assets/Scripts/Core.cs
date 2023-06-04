using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public float BHealth2 = 99.0f;
    public GameObject[] buildinglist;
    public GameObject Orb;
    public PlayerPunch pp2;
    private Collider buildingCol;
    public Collider buildingCol2;
    public bool building1 = true;
    public bool building2 = false;
    public bool building3 = false;
    public bool building4 = false;
    public bool building5 = false;
    public bool building6 = false;
    public bool orb = false;
    private bool dead = false;

    public ShieldGen ShieldScript;
    public GameObject Shield;
    //public bool shieldDead;

    public GameObject End;
    public Orb orbScript;
    public bool On = false;


    //[Header("sound")]
    //public AudioClip breaking1;
    //public AudioClip breaking2;
    //public AudioClip breaking3;
    //public AudioClip breaking4;
    //public AudioClip breaking5;
    //public AudioClip orbSound;
    //public AudioClip orbDestroy;


    //public AudioSource audioSource;


    


    private void Start()
    {
        buildingCol = GetComponent<Collider>();
        // shieldDead = ShieldScript.GetComponent<ShieldGen>().shieldDead;
        //audioSource = GetComponent<AudioSource>();
        //audioSource.playOnAwake = false;
    }

    void FixedUpdate()
    {
        pp2 = PlayerPunch.body;

        if (orbScript.exploded)
        {
            StartCoroutine(YouWin());
        }

        if (ShieldScript.shieldDead == true)
        { 
            Destroy(Shield);
            Debug.Log("SHIELD DOWN");
            if (!On)
            {
                buildingCol.enabled = true;
                buildingCol2.enabled = true;
                On = true;
            }

        }


        if (BHealth2 < 80.0f && BHealth2 >= 60.0f)
        {

            building1 = false;
            building2 = true;
            buildinglist[0].SetActive(false);
            buildinglist[1].SetActive(true);
            
        }
        else if (BHealth2 < 60.0f && BHealth2 >= 40.0f)
        {

            building2 = false;
            building3 = true;
            buildinglist[1].SetActive(false);
            buildinglist[2].SetActive(true);
        }
        else if (BHealth2 < 40.0f && BHealth2 >= 20.0f)
        {
            building3 = false;
            building4 = true;
            orb = true;
            buildinglist[2].SetActive(false);
            buildinglist[3].SetActive(true);
            buildingCol2.enabled = false;
            Orb.SetActive(true);

        }
        else if (BHealth2 < 20.0f && BHealth2 > 0.0f)
        {
            building4 = false;
            building5 = true;
            buildinglist[3].SetActive(false);
            buildinglist[4].SetActive(true);

        }
        else if (BHealth2 <= 0.0f)
        {
            building4 = false;
            building5 = true;
            buildinglist[4].SetActive(false);
            buildinglist[5].SetActive(true);
            

            dead = true;
            if (dead)
            {
                buildingCol.enabled = false;
            }
        }
    }

    public void TakeDamage(float dmg)
    {
        BHealth2 -= dmg;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ShieldScript.shieldDead)
        {
            if (other.tag == "Fist" && building1 && pp2.isAttking)
            {
                BHealth2 -= 7.0f;
            }
            else if (other.tag == "Fist" && building2 && pp2.isAttking)
            {
                BHealth2 -= 7.0f;
            }
            else if (other.tag == "Fist" && building3 && pp2.isAttking)
            {
                BHealth2 -= 7.0f;
            }
            else if (other.tag == "Fist" && building4 && pp2.isAttking)
            {
                BHealth2 -= 7.0f;
            }
            else if (other.tag == "Fist" && building5 && pp2.isAttking)
            {
                BHealth2 -= 7.0f;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (ShieldScript.shieldDead)
        {
            if (other.tag == "Laser" && building1)
            {
                BHealth2 -= 0.1f;
            }
            else if (other.tag == "Laser" && building2)
            {
                BHealth2 -= 0.1f;
            }
            else if (other.tag == "Laser" && building3)
            {
                BHealth2 -= 0.1f;
            }
            else if (other.tag == "Laser" && building4)
            {
                BHealth2 -= 0.1f;
            }
            else if (other.tag == "Laser" && building5)
            {
                BHealth2 -= 0.1f;
            }
        }
    }

    IEnumerator YouWin()
    {
        yield return new WaitForSeconds(2);
        End.SetActive(true);
        Time.timeScale = 0.0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}

