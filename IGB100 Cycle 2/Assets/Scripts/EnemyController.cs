using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   // public Animator animator;
    bool RightClick;

    void Start()
    {
       // animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
       

            RightClick = true;

        else

            RightClick = false;


        //if (RightClick == true)
         //   animator.SetBool("RightClick", true);

       // else
         //   animator.SetBool("RightClick", false);
    }
}
