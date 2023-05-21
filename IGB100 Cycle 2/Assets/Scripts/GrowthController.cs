using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthController : MonoBehaviour
{
    public float energyLevel = 95f;
    public float maxEnergy = 100f;
    public GameObject Player;
    public GameObject PlayerCam;
    public GameObject Titan;
    public GameObject TitanCam;
    public bool Grow = false;

    public float dynFriction;
    public float statFriction;
    public Collider col;


    void OnEnable()
    {
        col = GetComponent<Collider>();
    }

    void Update()
    {
        print(Grow);
        // Keep energy level between 0 - 100
        if (energyLevel < 0)
        { 
            energyLevel = 0;

        } else if (energyLevel > maxEnergy)
        {
            energyLevel = maxEnergy;
        }
        // controls form toggling 
        if(energyLevel == 100 && !Grow)
        {
            Grow = true;
            Player.SetActive(false);
            PlayerCam.SetActive(false);

            Titan.SetActive(true);
            TitanCam.SetActive(true);

        }

        if (energyLevel <= 0 && Grow == true)
        {
            Grow = false;
            Player.SetActive(true);
            PlayerCam.SetActive(true);

            Titan.SetActive(false);
            TitanCam.SetActive(false);
        }
        // controls energy draining
        if (Grow == true)
        {
            energyLevel -= 3f * Time.deltaTime;
        }
    }

    public void Recharge()
    {
        
        if (energyLevel < maxEnergy && !Grow)
            energyLevel += 0.1f;
    }


}  
