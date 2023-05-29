using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutAnimation : MonoBehaviour
{
    public GameObject Scout;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Animator anim = Scout.GetComponent<Animator>();
            anim.SetBool("Charging", true);
        }
        else if (Input.GetMouseButtonUp(0)) 
        {
            Animator anim = Scout.GetComponent<Animator>();
            anim.SetBool("Charging", false);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Animator anim = Scout.GetComponent<Animator>();
            anim.SetBool("Driving", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            Animator anim = Scout.GetComponent<Animator>();
            anim.SetBool("Driving", false);
        }
    }
}
