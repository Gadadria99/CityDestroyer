using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullDestruction : MonoBehaviour
{
    public float BHealth2 = 99.0f;
    public GameObject[] buildinglist;
    public PlayerPunch pp2;
    private Collider buildingCol;
    public bool building1 = true;
    public bool building2 = false;
    public bool building3 = false;
    public bool building4 = false;
    private bool dead = false;


    private bool rolled = false;
    private float flip;
    private float chance;
    public GameObject HP;
    public GameObject NRG;

    [Header("sound")]
    public AudioClip breaking1;
    public AudioClip breaking2;
    public AudioClip breaking3;

    private void Start()
    {
        buildingCol = GetComponent<Collider>();

        
        GetComponent<AudioSource>().playOnAwake = false;
    }

    void Update()
    {
        pp2 = PlayerPunch.body;
        chance = Random.Range(0, 11);
        flip = Random.Range(0, 3);

        if (BHealth2 < 70.0f && BHealth2 >= 66.0f)
        {
            //Debug.Log("Health is: " + BHealth2);

            ////play sound 1
            //SingletonParams.Instance.PlaySoundFXClip(breaking1, transform, 0.2f);



            building1 = false;
            building2 = true;
            buildinglist[0].SetActive(false);
            buildinglist[1].SetActive(true);
        }
        else if (BHealth2 < 66.0f && BHealth2 >= 33.0f)
        {
            //Debug.Log("Health is: " + BHealth2);

            ////play sound 2
            //SingletonParams.Instance.PlaySoundFXClip(breaking2, transform, 0.2f);



            building2 = false;
            building3 = true;
            buildinglist[1].SetActive(false);
            buildinglist[2].SetActive(true);
        }
        else if (BHealth2 < 33.0f)
        {
            //Debug.Log("Health is: " + BHealth2);

            //play sound 3
            //SingletonParams.Instance.PlaySoundFXClip(breaking3, transform, 0.2f);


            building3 = false;
            building4 = true;
            buildinglist[2].SetActive(false);
            buildinglist[3].SetActive(true);
            dead = true;

            DropItem();
        }

        if (dead)
        {
            buildingCol.enabled = false;
        }
    }

    public void TakeDamage(float dmg)
    {
        BHealth2 -= dmg;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fist"))
        {
            if (building1 && pp2.isAttking)
            {

                BHealth2 -= 33.0f;
                //GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = breaking1;
                GetComponent<AudioSource>().Play();
            }
            else if (building2 && pp2.isAttking)
            {
                BHealth2 -= 33.0f;
                //GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = breaking2;
                GetComponent<AudioSource>().Play();
            }
            else if (building3 && pp2.isAttking)
            {
                BHealth2 -= 33.0f;

                //GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = breaking3;
                GetComponent<AudioSource>().Play();
            }
        }

        if (other.tag == "Laser" && building1)
        {
            GetComponent<AudioSource>().clip = breaking1;
            GetComponent<AudioSource>().Play();
        }
        else if (other.tag == "Laser" && building2)
        {
            GetComponent<AudioSource>().clip = breaking2;
            GetComponent<AudioSource>().Play();
        }
        else if (other.tag == "Laser" && building3)
        {
            GetComponent<AudioSource>().clip = breaking3;
            GetComponent<AudioSource>().Play();
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Laser" && building1)
        {
            BHealth2 -= 1.0f;
            if (BHealth2 < 70)
            {
                building1 = false;
                buildinglist[0].SetActive(false);
            }
        }
        else if (other.tag == "Laser" && building2)
        {
            BHealth2 -= 1.0f;
        }
        else if (other.tag == "Laser" && building3)
        {
            BHealth2 -= 1.0f;
        }
    }

    private void DropItem()
    {
        if (rolled == false)
        {
            if (chance <= 3)
            {
                if (flip == 0)
                {
                    Instantiate(HP, new Vector3(transform.position.x, 32, transform.position.z), transform.rotation);
                }
                else if (flip <= 1)
                {
                    Instantiate(NRG, new Vector3(transform.position.x, 32, transform.position.z), transform.rotation);
                }
            }
            rolled = true;
        }
    }
}
