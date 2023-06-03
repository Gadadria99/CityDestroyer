using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {

        if (!collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("bullet destroyed");
            Destroy(this.gameObject);
        }
    }
}