using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthController : MonoBehaviour
{
    public float energyLevel = 95f;
    public float maxEnergy = 100f;
    private bool goUp = false;
    public GameObject Player;
    public GameObject PlayerCam;
    public GameObject Titan;
    public GameObject TitanCam;
    public bool Grow = false;
   // public GameObject playerObj;

    public float dynFriction;
    public float statFriction;
    public Collider col;



    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        //setScale();

        if(energyLevel >= 100 && !Grow)
        {
            Grow = true;
            Player.SetActive(false);
            PlayerCam.SetActive(false);

            Titan.SetActive(true);
            TitanCam.SetActive(true);

        }


    }





    private void setScale()
    {
        if (energyLevel <= 0)
        {
            

            Player.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        else
        {
            if (energyLevel >= 100)
            {
                if (!goUp)
                {
                    Player.transform.localPosition = new Vector3(Player.transform.localPosition.x, 10, Player.transform.localPosition.z);
                    goUp = true;
                }
                Player.transform.localScale = new Vector3(20f, 40f, 20f);

                //playerObj.transform.GetComponent<GrowthController>().Recharge(90);
                //col.material.dynamicFriction = dynFriction;
                //col.material.staticFriction = statFriction;
            }

        }

    }

    public void Recharge()
    {
        if (energyLevel < maxEnergy)
            energyLevel += 0.1f;
        else
            energyLevel = maxEnergy;
    }


}  
