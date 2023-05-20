using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRay : MonoBehaviour
{
    public float length;
    RaycastHit hit;
    public float distance = 1500;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.up);

        Debug.DrawRay(transform.position, transform.up * length, Color.blue);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "World" || hit.collider.tag == "Building")
            {
                distance = hit.distance;
                //Debug.Log(hit.distance);
            }
        }
    }
}
