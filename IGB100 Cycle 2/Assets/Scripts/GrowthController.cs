using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthController : MonoBehaviour
{
    public float energyLevel = 0f;
    public float maxEnergy = 100f;
    public GameObject Player;
    //public GameObject playerObj;

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
        setScale();

        
    }





    private void setScale()
    {
        if (energyLevel <= 0)
        {
            

            Player.transform.localScale = new Vector3(1f, 1f, 1f);
        }



/*        else if (energyLevel < 80)
        {
            Player.transform.localScale = new Vector3(1f, 1f, 1f);
        }*/



        else
        {
            if (energyLevel >= 100)
            {
                Player.transform.localScale = new Vector3(25f, 40f, 25f);

                // playerObj.transform.GetComponent<GrowthController>().Recharge(90);
                col.material.dynamicFriction = dynFriction;
                col.material.staticFriction = statFriction;
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
