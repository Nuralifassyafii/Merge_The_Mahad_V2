using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float walkSpeedHor;
    [SerializeField] private float runSpeed;
    [SerializeField] private Transform transpos;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;

    // REFERENCES
    private CharacterController controller;
    private Animator anim;

    //alip

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
            {
                // GetKey = apabila menggunakan fungsi tombol tekan dan tahan
                WalkFWD();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift))
            {
                // GetKey = apabila menggunakan fungsi tombol tekan dan tahan
                WalkBWD();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                RunFWD();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
            {
                RunBWD();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }

            /*else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift))
            {
                WalkLeft();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift))
            {
                WalkRight();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            {
                RunLeft();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            {
                RunRight();
            }*/

            moveDirection *= moveSpeed;

            if (moveDirection == Vector3.zero && Input.GetKeyDown(KeyCode.Space))
            {
                // GetKeyDown = aoabila menggunakan fungsi tombol sekali tekan
                jump();
            }

            if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Space))
            {
                bigJump();
            }
        }

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    
    private void Idle()
    {
        anim.SetFloat("moveVer", 0, 0.1f, Time.deltaTime);
    }
    private void WalkFWD()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("moveVer", 0.5f, 0.1f, Time.deltaTime);
    }
    private void RunFWD()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("moveVer", 1, 0.1f, Time.deltaTime);
    }
    private void WalkBWD()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("moveVer", -0.5f, 0.1f, Time.deltaTime);
    }
    private void RunBWD()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("moveVer", -1, 0.1f, Time.deltaTime);
    }

/*    private void RunLeft()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("MoveHor", -1);
    }
    private void WalkLeft()
    {
        moveSpeed = walkSpeedHor;
        anim.SetTrigger("walkLeft");
    }
    private void WalkRight()
    {
        moveSpeed = walkSpeedHor;
        anim.SetTrigger("walkRight");
    }
    private void RunRight()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("MoveHor", 1);
    }*/

    private void jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetTrigger("Jump");
    }

    private void bigJump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -1 * gravity);
        anim.SetTrigger("BigJump");
    }

    
}
