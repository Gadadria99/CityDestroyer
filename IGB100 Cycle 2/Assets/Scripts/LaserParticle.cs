using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserParticle : MonoBehaviour
{
    public GameObject Particle;
    public Vector3 loc;
    private float dis;

    private void Update()
    {
        //dis = GameObject.FindWithTag("Cannon").GetComponent<CannonRay>().distance;
        //loc = new Vector3(dis, transform.position.y, transform.position.z);
    }
    private void OnTriggerStay(Collider other)
    {
        var p = Instantiate(Particle, transform.position, Quaternion.identity);
        Destroy(p, 1);
    }
}
