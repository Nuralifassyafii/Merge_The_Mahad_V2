using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rb;
    public CharacterController controller;
    public float walkSpeed;
    public float runSpeed;
    public float rotationSpeed;
    public float olw_speed;
    public bool walking;
    public Transform playerTrans;
    public float JawabanBenar = Soal.jwbBenar;
    public bool Pengalaman;
    public float waktu = Soal.scorewaktu;
    Soal codingsoal;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * walkSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.forward * walkSpeed * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        walkForward();
        walkBackward();
        walkRight();
        walkLeft();
        runFwd();
        runBwd();
    }

    void walkForward()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("walkfwd");
            anim.ResetTrigger("idle");
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.ResetTrigger("walk");
            anim.SetTrigger("idle");
            walking = false;
        }
    }

    void walkBackward()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("walkbwd");
            anim.ResetTrigger("idle");
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.ResetTrigger("walkbwd");
            anim.SetTrigger("idle");
            walking = false;
        }
    }

    void walkRight()
    {
        if (Input.GetKey(KeyCode.A)){
            playerTrans.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
    }
    
    void walkLeft()
    {
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }

    void runFwd()
    {
        if (walking == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                walkSpeed = walkSpeed + runSpeed;
                anim.SetTrigger("runfwd");
                anim.ResetTrigger("walk");
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                walkSpeed = olw_speed;
                anim.ResetTrigger("runfwd");
                anim.SetTrigger("walk");
            }
        }

    }
    void runBwd()
    {
        if (walking == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                walkSpeed = walkSpeed + runSpeed;
                anim.SetTrigger("runbwd");
                anim.ResetTrigger("walk");
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                walkSpeed = olw_speed;
                anim.ResetTrigger("runbwd");
                anim.SetTrigger("walkfwd");
            }
        }

    }

}
