using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public GameObject Titan;
    public bool CanAttk = true;
    public float AttkCD = 0.3f;
    public bool isAttking = false;
    public bool armToggle = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Animator walk = Titan.GetComponent<Animator>();
            walk.SetTrigger("Walking");
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttk)
            {
                PunchAttk();
            }
        }
    }

    public void PunchAttk()
    {
        isAttking = true;
        CanAttk = false;
        if (armToggle == false)
        {
            Animator anim = Titan.GetComponent<Animator>();
            anim.SetTrigger("Attk");
            armToggle = true;
        }
        else if (armToggle == true)
        {
            Animator anim = Titan.GetComponent<Animator>();
            anim.SetTrigger("Attk2");
            armToggle = false;
        }
        StartCoroutine(ResetAttkCD());
    }

    IEnumerator ResetAttkCD()
    {
        StartCoroutine(ResetAttkBool());
        yield return new WaitForSeconds(AttkCD);
        CanAttk = true;
    }

    IEnumerator ResetAttkBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttking = false;

    }
}