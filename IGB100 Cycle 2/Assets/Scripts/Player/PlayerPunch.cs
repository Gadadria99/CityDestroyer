using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    public GameObject FistR;
    public GameObject FistL;
    public GameObject Cannon;

    public bool isShooting = false;
    public bool CanAttk = true;
    public bool Swap = false;
    public bool isAttking = false;
    public bool cannonOut = false;
    public float AttkCD = 0.5f;

    public static PlayerPunch body;

    void Awake() 
    {
        body = this;
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (CanAttk)
            {
                PunchAtk();
            }
        }
        if (Input.GetMouseButton(1))
        { 
            Shoot();
        }
        if (Input.GetMouseButtonUp(1))
        {
            isShooting = false;

            Animator anim = FistL.GetComponent<Animator>();
            anim.SetTrigger("Draw");

            Animator anim2 = FistL.GetComponent<Animator>();
            anim2.SetTrigger("Return");
        }
    }

    public void PunchAtk()
    {
        isAttking = true;
        CanAttk = false;

        if (Swap == false)
        {
            Animator anim = FistR.GetComponent<Animator>();
            anim.SetTrigger("Attk");
            StartCoroutine(ResetAtkCD());
            Swap = true;
        }
        else if (Swap == true) 
        {
            Animator anim = FistL.GetComponent<Animator>();
            anim.SetTrigger("Attk2");
            StartCoroutine(ResetAtkCD());
            Swap = false;
        }
    }

    public void Shoot() 
    {
        isShooting = true;

        Animator anim = FistL.GetComponent<Animator>();
        anim.SetTrigger("Holster");

        Animator anim2 = Cannon.GetComponent<Animator>();
        anim2.SetTrigger("Draw");

        cannonOut = true;

        if (cannonOut == true)
        {
            Animator anim3 = Cannon.GetComponent<Animator>();
            anim3.SetTrigger("Shoot");

            if (Input.GetMouseButtonUp(1))
            {
                cannonOut = false;
                Animator anim4 = Cannon.GetComponent<Animator>();
                anim4.SetTrigger("Holster");
            }
        }


    }

    IEnumerator ResetAtkCD()
    {
        StartCoroutine(ResetAtkBool());
        yield return new WaitForSeconds(AttkCD);
        CanAttk = true;
    }

    IEnumerator ResetAtkBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttking = false;
        
    }
}
