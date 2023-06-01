using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutFollow : MonoBehaviour
{
    
    public bool aligned = false;
    //private float gc;
   // public GameObject titan;
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
        Transform titanPosition = SingletonParams.Instance.titanPosition;

        if (energylvl < 1 && !aligned)
        {
            
            transform.position = new Vector3(titanPosition.transform.position.x, transform.position.y, titanPosition.transform.position.z);
            aligned = true;
        }
    }
}
