using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbRotate : MonoBehaviour
{
    public float rotateSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime);
    }
}
