using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [Header("Movement")]
    public float moveSpeed;
    public float walkSpeed;
    public float runSpeed;
    public float wallrunSpeed;
    public movementState state;


    [Header("Slope Movement")]
    public float maxSlopeAngle;
    public RaycastHit slopeHit;



    public float groundDrag;
    public float jumpForce;
    public float airMultiplier;
    public float jumpCooldown;
    bool readyToJump;
    public bool wallrunning;


    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode runKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask WhatGround;
    bool grounded;


    public Transform orientation;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;

    }

    private void Update()
    {
        //check if on ground plane

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, WhatGround);

        //drag 

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }

        MyInput();
        StateHandler();

    }

    private void FixedUpdate()
    {

        MovePlayer();
    }


    private void MyInput()
    {
        // set up variables for directional movement

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump

        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        //slopemovement
        if (OnSlope())
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }

        //turn G off while onslope
        rb.useGravity = !OnSlope();



        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;



        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        

    }

    private void jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
       
    }
    
    private void ResetJump()
    {
        readyToJump = true;
    }

    public enum movementState
    {
        walking,
        running,
        wallrunning,
        air
    }

    //handles walking/sprinting state 
    private void StateHandler()
    {

        //wallrunning
        if (wallrunning)
        {
            state = movementState.wallrunning;
            moveSpeed = wallrunSpeed;
        }

        //running
        else if(grounded && Input.GetKey(runKey))
        {
            state = movementState.running;
            moveSpeed = runSpeed;
        }

        //walking
        else if(grounded)
        {
            state = movementState.walking;
            moveSpeed = walkSpeed;
        }

        else
        {
            state = movementState.air;
            rb.useGravity = true;
        }
    }

    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

}
