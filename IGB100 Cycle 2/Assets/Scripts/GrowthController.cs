using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthController : MonoBehaviour
{

    public GameObject Player;
    public GameObject PlayerCam;
    public GameObject Titan;
    public GameObject TitanCam;
    public bool Grow;

    public float dynFriction;
    public float statFriction;
    public Collider col;
    public float eL;
    public float mE;
    public PlayerPunch pp;
    //public float eLfwd = 0;
    //public float eRfwd;
   // public PlayerUI pUI;

    void OnEnable()
    {
        col = GetComponent<Collider>();

        mE = SingletonParams.Instance.maxEnergy;
        //eL = SingletonParams.Instance.energyLevel;
        //Grow = SingletonParams.Instance.Grow;
    }

    void Update()
    {
        eL = SingletonParams.Instance.energyLevel;
        Grow = SingletonParams.Instance.Grow;

        //if (eLfwd == 0)
        //{
        //    eRfwd = eL;
        //}
        //else
        //{
        //    eRfwd = (eL + eLfwd);
        //}

        //eRfwd = (eL + eLfwd);
        //print(Grow);
        // Keep energy level between 0 - 100

        // controls form toggling 


        // controls energy draining
        growState();

    }


    public void growState()
    {
        if (eL >= 100 && !Grow)
        {
            //Player.transform.position = new Vector3(1, 0, 0);
            
            Player.SetActive(false);
            PlayerCam.SetActive(false);
            Titan.SetActive(true);
            TitanCam.SetActive(true);
            SingletonParams.Instance.Grow = true;

        }

        else if (eL <= 0 && Grow == true)
        {
            //eLfwd = 0;

            pp.isShooting = false;
            pp.isAttking = false;
            Titan.SetActive(false);
            TitanCam.SetActive(false);
            Player.SetActive(true);
            PlayerCam.SetActive(true);
            SingletonParams.Instance.Grow = false;

        }

        else if (Grow == true)
        {

            SingletonParams.Instance.energyDrain(2.5f);

        }



    }
    //public void Recharge(float eVal)
    //{
    //    if (eL < mE)
    //    {
    //        eLfwd += (eVal * Time.deltaTime);
    //    }
    //}

}  
