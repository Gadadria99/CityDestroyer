using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunning : MonoBehaviour
{

    [Header("Wallrunning")]
    public LayerMask WhatWall;
    public LayerMask WhatGround;
    public float wallRunForce;
    public float maxWallRunTime;
    public float wallClimbSpeed;
    public float wallJumpForce;
    public float wallJumpSideForce;

    


    [Header("Input")]
    private float horizontalInput;
    private float verticalInput;
    public KeyCode upRun = KeyCode.LeftShift;
    public KeyCode downRun = KeyCode.LeftAlt;
    private bool upRunning;
    private bool downRunning;
    public KeyCode jumpKey = KeyCode.Space;


    [Header("Detection")]
    public float wallCheckDistance;
    public float minJumpHeight;
    private RaycastHit leftWallHit;
    private RaycastHit rightWallHit;
    private bool wallLeft;
    private bool wallRight;

    public Transform orientation;
    private PlayerMovement pm;
    private Rigidbody rb;
    //must be set to same value as playerHeight in pm script
    public float playerHeight;
    public GrowthController gc;


    // Start is called before the first frame update
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
        

}

    // Update is called once per frame
    void Update()
    {
        CheckForWall();
        StateMachine();

    }

    private void FixedUpdate()
    {
        if (pm.wallrunning)
        {
            WallRunningMovement();
        }
    }


    private void CheckForWall()
    {
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallHit, wallCheckDistance, WhatWall);
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallHit, wallCheckDistance, WhatWall);
    }

    private bool AboveGround()
    {
        if (SingletonParams.Instance.Grow == false)
        {
            return !Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, WhatGround);
        }

        else
        {
            return !Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 20f, WhatGround);
        }
    }

    private void StateMachine()
    {

        //get key inputs

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        upRunning = Input.GetKey(upRun);
        downRunning = Input.GetKey(downRun);

        if ((wallLeft || wallRight) && verticalInput > 0 && AboveGround())
        {
            //start wallrun

            if (!pm.wallrunning)
                StartWallRun();

            if (Input.GetKeyDown(jumpKey)) 
                WallJump();
        }

        else
        { 
            if(pm.wallrunning)
            {
                StopWallRun();
            }
        }
        
    }

    private void StartWallRun()
    {
        pm.wallrunning = true;
    }

    private void StopWallRun()
    {

        pm.wallrunning = false;
        rb.useGravity = true;


    }

    private void WallRunningMovement()
    {
        rb.useGravity = false;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        Vector3 wallNormal = wallRight ? rightWallHit.normal : leftWallHit.normal;

        Vector3 wallForward = Vector3.Cross(wallNormal, transform.up);

        if((orientation.forward - wallForward).magnitude > (orientation.forward - -wallForward).magnitude)
            wallForward = -wallForward;

        //wall climb/ descend movement

        if (upRunning)
            rb.velocity = new Vector3(rb.velocity.x, wallClimbSpeed, rb.velocity.z);

        if (downRunning)
            rb.velocity = new Vector3(rb.velocity.x, -wallClimbSpeed, rb.velocity.z);

        //forward movement

        rb.AddForce(wallForward * wallRunForce, ForceMode.Force);

        //push player to wall
        if(!(wallLeft && horizontalInput > 0) && !(wallRight && horizontalInput < 0))
        rb.AddForce(-wallNormal * 100, ForceMode.Force);

    }

    private void WallJump()
    {
        Vector3 wallNormal = wallRight ? rightWallHit.normal : leftWallHit.normal;

        Vector3 forceToApply = transform.up * wallJumpForce + wallNormal * wallJumpSideForce;

        
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        //add force
        rb.AddForce(forceToApply, ForceMode.Impulse);
    }

}
