using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanFollow : MonoBehaviour
{
    public Transform ScoutPosition;
    public bool aligned = false;
    private GrowthController gc;
    public GameObject scout;
    private float energylvl;


    private void OnEnable()
    {
        aligned = false;
    }
    void Update()
    {
        gc = scout.GetComponent<GrowthController>();

        energylvl = gc.energyLevel;

        if (energylvl >= 100 && !aligned)
        {
            aligned = true;
            transform.position = new Vector3(ScoutPosition.transform.position.x, transform.position.y, ScoutPosition.transform.position.z);
        }
    }
}
