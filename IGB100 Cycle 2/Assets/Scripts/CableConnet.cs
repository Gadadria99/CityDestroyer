using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableConnet : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.GetComponent<GrowthController>().Recharge();
        }
    }
}
