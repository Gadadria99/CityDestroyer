using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableConnet : MonoBehaviour
{

    public bool Grow;

    public AudioClip EnergyChargeSound;
    public AudioClip chargeSoundExit;
    public GameObject Scout;
    Collider Col;
     
    // Add your Audi Clip Here;
    // This Will Configure the  AudioSource Component; 
    // MAke Sure You added AudioSouce to sound area;
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        //GetComponent<AudioSource>().clip = EnergyChargeSound;
        Col = GetComponent<Collider>();
    }

    void Update()
    {
        Grow = SingletonParams.Instance.Grow;
        if(Grow)
        {
            GetComponent<AudioSource>().Stop();
        }
    }

    //Plays Sound Whenever collision detected

    // Make sure that sound area has a collider, box, or mesh.. ect..,
    // Make sure to turn "off" collider trigger for your sound Area;
    // Make sure That anything that collides into sound area, is rigidbody;



    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && SingletonParams.Instance.Grow == false)
        {


            //SingletonParams.Instance.PlaySoundFXClip(EnergyChargeSound, transform, 0.2f);
            //EnergyChargeSound.Play();
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = EnergyChargeSound;
            GetComponent<AudioSource>().Play();
        }
        else if (!Scout.activeSelf)
        {
            GetComponent<AudioSource>().Stop();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && SingletonParams.Instance.Grow == false)
        {
            SingletonParams.Instance.Recharge(5);

            //SingletonParams.Instance.PlaySoundFXClip(EnergyChargeSound, transform, 0.2f);
            //EnergyChargeSound.Play();
            //GetComponent<AudioSource>().Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player"/* && SingletonParams.Instance.Grow == false*/)
        {
            //Destroy(EnergyChargeSound);
            //SoundFXManager.instance.PlaySoundFXClip(EnergyChargeSound, transform, 0.2f);
            //EnergyChargeSound.Stop();
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = chargeSoundExit;
            GetComponent<AudioSource>().Play();
        }
    }
}
