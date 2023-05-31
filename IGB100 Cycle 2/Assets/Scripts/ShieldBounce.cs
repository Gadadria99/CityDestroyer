using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBounce : MonoBehaviour
{
    public float bounceForce;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRB = collision.rigidbody;
        
        if (collision.transform.tag == "Shield")
        {
            otherRB.AddExplosionForce(bounceForce, collision.contacts[0].point, 5);
        }
    }
}
