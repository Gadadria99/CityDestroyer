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
    


    [Header("Input")]
    private float horizontalInput;
    private float verticalInput;
    public KeyCode upRun = KeyCode.LeftShift;
    public KeyCode downRun = KeyCode.RightAlt;
    private bool upRunning;
    private bool downRunning;



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



    // Start is called before the first frame update
    void Start()
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
        if(pm.wallrunning)
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
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, WhatGround);
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

            if(!pm.wallrunning)
            {
                StartWallRun();
            }
            else
            {
                if(pm.wallrunning)
                {
                    StopWallRun();
                }
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

}
