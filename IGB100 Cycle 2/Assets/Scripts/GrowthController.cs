using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthController : MonoBehaviour
{

    public GameObject Player;
    public GameObject PlayerCam;
    public GameObject Titan;
    public GameObject TitanCam;
    public bool Grow = false;

    public float dynFriction;
    public float statFriction;
    public Collider col;
    public float eL;
    public float mE;
    public float eLfwd = 0;
    public float eRfwd;
    public PlayerUI pUI;

    void OnEnable()
    {
        col = GetComponent<Collider>();

        mE = GameObject.FindWithTag("PlayerBody").GetComponent<PlayerUI>().maxEnergy;
        pUI = GameObject.FindWithTag("PlayerBody").GetComponent<PlayerUI>();
    }

    void Update()
    {

        eL = GameObject.FindWithTag("PlayerBody").GetComponent<PlayerUI>().energyLevel;
        //if (eLfwd == 0)
        //{
        //    eRfwd = eL;
        //}
        //else
        //{
        //    eRfwd = (eL + eLfwd);
        //}

        eRfwd = (eL + eLfwd);
        print(Grow);
        // Keep energy level between 0 - 100

        // controls form toggling 
        if(eL == 100 && !Grow)
        {
            Player.transform.position = new Vector3(1, 0, 0);
            Grow = true;
            Player.SetActive(false);
            PlayerCam.SetActive(false);

            Titan.SetActive(true);
            TitanCam.SetActive(true);
            

        }

        else if (Grow == true)
            {
            
            pUI.energyDrain(5f);
 
        }

        else if (eL <= 0 && Grow == true)
        {
            eLfwd = 0;
            Grow = false;
            Player.SetActive(true);
            PlayerCam.SetActive(true);

            Titan.SetActive(false);
            TitanCam.SetActive(false);

        }

 
        // controls energy draining


    }

    public void Recharge(float eVal)
    {
        if (eL < mE)
        {
            eLfwd += (eVal * Time.deltaTime);
        }
    }

}  
