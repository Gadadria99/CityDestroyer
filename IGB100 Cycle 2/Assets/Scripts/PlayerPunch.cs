using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    public GameObject FistR;
    public bool CanAttk = true;
    public float AttkCD = 0.5f;
    public bool isAttking = false;

    public static PlayerPunch body;

    void Awake() 
    {
        body = this;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttk)
            {
                PunchAtk();
            }
        }
    }

    public void PunchAtk()
    {
        isAttking = true;
        CanAttk = false;
        Animator anim = FistR.GetComponent<Animator>();
        anim.SetTrigger("Attk");
        StartCoroutine(ResetAtkCD());
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
