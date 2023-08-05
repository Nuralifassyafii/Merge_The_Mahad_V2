using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float walkSpeedHor;
    [SerializeField] private float runSpeed;
    // [SerializeField] private float runSpeedHor;


    private Vector3 moveDirectionX;
    private Vector3 moveDirectionZ;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;

    // REFERENCES
    private CharacterController controller;
    private Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirectionZ = new Vector3(0, 0, moveZ);
        moveDirectionZ = transform.TransformDirection(moveDirectionZ);

        moveDirectionX = new Vector3(moveX, 0, 0);
        moveDirectionX = transform.TransformDirection(moveDirectionX);


        if (isGrounded)
        {
            if (moveDirectionZ != Vector3.zero && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
            {
                WalkFWD();
            }
            if (moveDirectionX != Vector3.zero && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift))
            {
                WalkLeft();
            }
            else if (moveDirectionZ != Vector3.zero && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift))
            {
                WalkBWD();
            }
            else if (moveDirectionX != Vector3.zero && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift))
            {
                WalkRight();
            }

            else if (moveDirectionZ != Vector3.zero && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                RunFWD();
            }
            /*else if (moveDirectionX != Vector3.zero && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            {
                RunLeft();
            }*/
            else if (moveDirectionZ != Vector3.zero && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
            {
                RunBWD();
            }
            /*else if (moveDirectionX != Vector3.zero && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            {
                RunRight();
            }*/
            else if (moveDirectionZ == Vector3.zero && moveDirectionX == Vector3.zero)
            {
                Idle();
            }

            moveDirectionZ *= moveSpeed;
            moveDirectionX *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                // GetKeyDown = aoabila menggunakan fungsi tombol sekali tekan
                jump();
            }

        }

        controller.Move(moveDirectionZ * Time.deltaTime);
        controller.Move(moveDirectionX * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    // Vertical
    private void Idle()
    {
        anim.SetTrigger("idle");
    }
    private void WalkFWD()
    {
        moveSpeed = walkSpeed;
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("walkfwd");
            anim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.ResetTrigger("walkfwd");
            anim.SetTrigger("idle");
        }
    }
    private void RunFWD()
    {
        moveSpeed = runSpeed;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetTrigger("runfwd");
            anim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.ResetTrigger("runfwd");
            anim.SetTrigger("idle");
        }
    }
    private void WalkBWD()
    {
        moveSpeed = walkSpeed;
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("walkbwd");
            anim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.ResetTrigger("walkbwd");
            anim.SetTrigger("idle");
        }

    }
    private void RunBWD()
    {
        moveSpeed = runSpeed;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetTrigger("runbwd");
            anim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.ResetTrigger("runbwd");
            anim.SetTrigger("idle");
        }
    }

    // Horizontal
    private void WalkLeft()
    {
        moveSpeed = walkSpeedHor;
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("walkL");
            anim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.ResetTrigger("walkL");
            anim.SetTrigger("idle");
        }
    }
    /*private void RunLeft()
    {
        moveSpeed = runSpeedHor;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetTrigger("runL");
            anim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.ResetTrigger("runL");
            anim.SetTrigger("idle");
        }
    }*/

    private void WalkRight()
    {
        moveSpeed = walkSpeedHor;
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("walkR");
            anim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.ResetTrigger("walkR");
            anim.SetTrigger("idle");
        }
    }
    /*private void RunRight()
    {
        moveSpeed = walkSpeedHor;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetTrigger("runR");
            anim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.ResetTrigger("runR");
            anim.SetTrigger("idle");
        }
    }*/

    private void jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetTrigger("Jump");
    }
}
