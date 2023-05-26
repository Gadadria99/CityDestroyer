using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutFollow : MonoBehaviour
{
    public Transform titanPosition;
    public bool aligned = false;
    private float gc;
   // public GameObject titan;
    private float energylvl;


    private void OnEnable()
    {
        aligned = false;
    }
    void Update()
    {
        gc = GameObject.FindWithTag("PlayerBody").GetComponent<PlayerUI>().energyLevel;

        energylvl = gc;

        if (energylvl <= 0 && !aligned)
        {
            aligned = true;
            transform.position = new Vector3(titanPosition.transform.position.x, transform.position.y, titanPosition.transform.position.z);
        }
    }
}
