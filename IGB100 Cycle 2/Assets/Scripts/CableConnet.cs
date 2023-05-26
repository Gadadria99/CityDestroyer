using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableConnet : MonoBehaviour
{

    public AudioClip EnergyChargeSound;

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.GetComponent<GrowthController>().Recharge(1);

            SoundFXManager.instance.PlaySoundFXClip(EnergyChargeSound, transform, 0.2f);
        }
    }
}
