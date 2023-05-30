using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject Player;
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
    public float jumpForceSuper;
    public float airMultiplier;
    public float jumpCooldown;
    public float jumpCooldown2 = 5.0f;
    bool readyToJump;
    bool readyToJumpSuper;
    public bool wallrunning;
    public bool jumpIsSuper;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode runKey = KeyCode.LeftShift;
    public KeyCode superJumpKey = KeyCode.Q;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask WhatGround;
    public bool grounded;


    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    public float fallMultiplier = 20f;
    Rigidbody rb;
    public bool Grow;
    Vector3 moveDirection;

    //public GrowthController gc;





    // Start is called before the first frame update
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        readyToJumpSuper = true;
        Physics.gravity = new Vector3(0, -40.0F, 0);
        

    }

    private void Update()
    {
        //check if on ground plane

        Grow = SingletonParams.Instance.Grow;


        if (Grow == false)
        {
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, WhatGround);
        }
            

            else
        {
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 20f, WhatGround);
        }
            




        // if()
        // grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 20.0f, WhatGround);

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
        SpeedControl();

    }

    private void FixedUpdate()
    {

        MovePlayer();

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.deltaTime;
        }
    }


    private void MyInput()
    {
        // set up variables for directional movement

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }

        if ((Input.GetKey(jumpKey) && Input.GetKey(superJumpKey)) && readyToJump && grounded)
        {
            readyToJumpSuper = false;
            jumpSuper();
            Invoke(nameof(ResetJumpSuper), jumpCooldown2);
            jumpIsSuper = true;

        }
        else
        {
            if(jumpIsSuper && grounded)
            {
                AreaDamageBuildings(Player.transform.position, 50.0f, 100.0f);
            }
        }
    }

    void AreaDamageBuildings(Vector3 location, float radius, float damage)
    {
        Collider[] buildingsInRange = Physics.OverlapSphere(location, radius);

        foreach (Collider col in buildingsInRange)
        {
            FullDestruction building = col.GetComponent<FullDestruction>();
            if (building != null)
            {
                // linear falloff of effect
                float proximity = (location - building.transform.position).magnitude;
                float effect = 1 - (proximity / radius);

                building.TakeDamage(damage * effect);
            }
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

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit speed if over threshold

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }

    private void jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
       
    }

    private void jumpSuper()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForceSuper, ForceMode.Impulse);
    }

    
    private void ResetJump()
    {
        readyToJump = true;
    }

    private void ResetJumpSuper()
    {
        readyToJumpSuper = true;
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
