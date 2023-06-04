using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOff : MonoBehaviour
{
    public bool Grow;
    public Collider PowerStation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Grow = SingletonParams.Instance.Grow;
        if (Grow)
        {
            PowerStation.enabled = false;
        }
        else
        {
            PowerStation.enabled = true;
        }
    }
}
