using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public Punch p;
    //public GameObject HitParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Building" && p.isAttking)
        {
            other.GetComponent<Animator>().SetTrigger("Hit");
            //Instantiate(HitParticle, new Vector3(other.transform.position.x,
            //transform.position.y, other.transform.position.z)
            //other.transform.rotation);
        }
    }
}
