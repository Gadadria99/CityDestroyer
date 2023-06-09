using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    public GameObject FistR;
    public GameObject FistL;
    public GameObject Cannon;
    public GameObject Enemy;

    public bool isShooting = false;
    public bool CanAttk = true;
    public bool Swap = false;
    public bool isAttking = false;
    public bool cannonOut = false;
    public float AttkCD = 0.5f;

    public Transform cannonRot;
    public Transform muzzle;
    public GameObject shotPrefab;
    private GameObject laser;
    public GameObject cannon;
    private float dis = 1500.0f;
    private Vector3 laserLength;

    public static PlayerPunch body;

    public AudioClip lazerSound;
    public AudioClip lazerSoundExit;
    public AudioClip swoosh;

    void Start()
    {
        body = this;
        GetComponent<AudioSource>().playOnAwake = false;
    }

    void Update()
    {
        dis = GameObject.FindWithTag("Cannon").GetComponent<CannonRay>().distance;
        //Debug.Log("laser length is: " + dis);
        laserLength = new Vector3(0.014f, 0.014f, dis * 0.0003f);
        
        if (isShooting == true) 
        {
            laser.transform.localScale = laserLength;
        }

        if (Input.GetMouseButton(0))
        {
            if (CanAttk)
            {
                PunchAtk();
                GetComponent<AudioSource>().clip = swoosh;
                GetComponent<AudioSource>().Play();
            }
        }
        if (Input.GetMouseButtonDown(1))
        { 
            Shoot();
            StartCoroutine(Laser());

            GetComponent<AudioSource>().clip = lazerSound;
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().Play();
        }
        if (Input.GetMouseButtonUp(1))
        {
            isShooting = false;
            Destroy(laser);
            GetComponent<AudioSource>().loop = false;
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = lazerSoundExit;
            GetComponent<AudioSource>().Play();

            Animator anim = FistL.GetComponent<Animator>();
            anim.SetTrigger("Draw");

            Animator anim2 = FistL.GetComponent<Animator>();
            anim2.SetTrigger("Return");

            cannonOut = false;
            print(cannonOut);
            Animator anim3 = Cannon.GetComponent<Animator>();
            anim3.SetBool("Shoot", false);
            
            Animator anim4 = Cannon.GetComponent<Animator>();
            anim4.SetTrigger("Holster");
        }

        if (isShooting == false) 
        {
            Destroy(laser);
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
        Animator anim = FistL.GetComponent<Animator>();
        anim.SetTrigger("Holster");

        Animator anim2 = Cannon.GetComponent<Animator>();
        anim2.SetTrigger("Draw");

        cannonOut = true;

        if (cannonOut == true)
        {
            Animator anim3 = Cannon.GetComponent<Animator>();
            anim3.SetBool("Shoot", true);
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
        yield return new WaitForSeconds(0.1f);
        isAttking = false;
        
    }

    IEnumerator Laser()
    {
        yield return new WaitForSeconds(0.0f);
        laser = GameObject.Instantiate(shotPrefab, muzzle.position, muzzle.rotation);
        laser.transform.SetParent(cannon.transform);
        //laser.transform.localScale = new Vector3(0, 0, dis);
        isShooting = true;
    }
}
