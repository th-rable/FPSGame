﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public GameObject Cam;


    CharacterController cc;
    public float hmove;
    public float vmove;
    public Vector3 dirmove;
    public float moveSpeed;

    public float GravitySpeed;
    public float yspeed = 0;

    public float jumpinput;
    public float JumpSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }
    void Start()
    {
        moveSpeed = StatManager.instance.PlayerMoveSpeed;
        GravitySpeed = StatManager.instance.GravitySpeed;
        JumpSpeed = StatManager.instance.JumpSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        
        Move();
        Gravity();
        Jump();
        Rotate();
    }


    void Gravity()
    {
        yspeed -= GravitySpeed;
        if (cc.isGrounded)
        {
       
            yspeed = -GravitySpeed;
        }
        dirmove = new Vector3(0, yspeed, 0);
        cc.Move(dirmove * Time.deltaTime);
    }
    void Move()
    {   
        hmove = Input.GetAxis("Horizontal");
        vmove = Input.GetAxis("Vertical");
        dirmove = new Vector3(hmove * moveSpeed, -GravitySpeed, vmove * moveSpeed);

        dirmove = transform.TransformDirection(dirmove);

        cc.Move(dirmove *  Time.deltaTime);
        
    }
    void Jump()
    {
        jumpinput = Input.GetAxis("Jump");
        if(cc.isGrounded && jumpinput == 1)
        {
            yspeed = JumpSpeed;
            dirmove = new Vector3(0, yspeed, 0);
            cc.Move(dirmove * Time.deltaTime);
            
        }
    }
    void Rotate()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, Cam.transform.rotation.eulerAngles.y, transform.rotation.z);
    }
}