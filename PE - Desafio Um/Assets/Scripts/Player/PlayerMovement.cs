using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDeathObserver
{
    public PlayerHealth _playerHealth;

    [Header("Refences")]
    public float moveSpeed;

    public float groundDrag;

    [Header("GroundCheck")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;
    float horizontalInput,
        verticalInput;

    Vector3 movementDirection;
    public Rigidbody rb;
    public bool isAlive;

    private void Start()
    {
        rb.freezeRotation= true;
        ObserveSubject();

    }
    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        MyInput();
        SpeedControl();

        if(grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


    private void MyInput()
    {
        if (isAlive)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }

    }

    private void MovePlayer()
    {
        if (isAlive)
        {
            // Calculate Movement
            movementDirection = orientation.forward * verticalInput + orientation.right* horizontalInput;
            rb.AddForce(movementDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit the velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    void ObserveSubject()
    {
        _playerHealth.AddDeathObserver(this);
    }

    public void OnNotifyDeath()
    {
        isAlive = false;
    }
}
