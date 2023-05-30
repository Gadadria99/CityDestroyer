using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanFollow : MonoBehaviour
{
    public Transform ScoutPosition;
    public bool aligned = false;
    //private float gc;
   // public GameObject scout;
    private float energylvl;
    //public bool Grow;

    private void OnEnable()
    {
       aligned = false;
    }
    void Update()
    {
        //gc = GameObject.FindWithTag("PlayerBody").GetComponent<PlayerUI>().energyLevel;
        //Grow = SingletonParams.Instance.Grow;
        energylvl = SingletonParams.Instance.energyLevel;

        if (energylvl >= 100 && !aligned)
        {
            aligned = true;
            transform.position = new Vector3(ScoutPosition.transform.position.x, transform.position.y, ScoutPosition.transform.position.z);
        }
    }
}
