using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonExample : MonoBehaviour
{
    private static SingletonExample manager;
    public static SingletonExample Instance { get { return manager; } }

    public float maxEnergy;
    public float energyLevel;
    public bool Grow = false;

    void Awake()
    {
        if (manager != null && manager != this)
            Destroy(gameObject);
        else
            manager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (energyLevel < 0)
        {
            energyLevel = 0;


        }
        else if (energyLevel > maxEnergy)
        {
            energyLevel = maxEnergy;
        }
    }

    public void Recharge(float eVal)
    {
        
            if (energyLevel < maxEnergy)
            {
                energyLevel += (eVal * Time.deltaTime);
            }
        
    }

    public void energyDrain(float nrgVal)
    {
        if (energyLevel >= 0)
        {
            energyLevel -= (nrgVal * Time.deltaTime);
        }

    }
}
