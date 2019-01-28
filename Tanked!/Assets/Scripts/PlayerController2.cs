﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController2 : MonoBehaviour
{
    [SerializeField] public float Speed = 0.5f;
    private float vertical1;
    private float horizontal1;
    [SerializeField] public float limit = 0.7f;
    Rigidbody2D rigid;
    private Vector2 moveDirection;
    //private Vector2 moveDirection1;
    float rotationAngle;
    float smoothTime = 1.0f;
    Quaternion desiredRotation;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {

        horizontal1 = Input.GetAxisRaw("Horizontal1");
        vertical1 = Input.GetAxisRaw("Vertical1");
        GetInput1();
        desiredRotation = Quaternion.Euler(0, 0, rotationAngle);
        //transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothTime*0.1f);
    }
    private void FixedUpdate()
    {
        if (horizontal1 != 0 && vertical1 != 0)
        {
            Moving();
        }
        else
        {
            Moving();
        }

    
    
    }
    private void GetInput1()
    {

        moveDirection = Vector2.zero;
        float rotationAngle;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            moveDirection += Vector2.up;

            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothTime);
            rotationAngle = 90;
            rigid.transform.Rotate(0, 0, rotationAngle);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDirection += Vector2.down;
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothTime);
            rotationAngle = -90;
            rigid.transform.Rotate(0, 0, rotationAngle);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDirection += Vector2.left;
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothTime);
            rotationAngle = 180;
            rigid.transform.Rotate(0, 0, rotationAngle);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDirection += Vector2.right;
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothTime);
            rotationAngle = 0;
            rigid.transform.Rotate(0, 0, rotationAngle);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Shell>().Shoot();
        }
    }
    public void Moving()
    {
        rigid.velocity = new Vector2((horizontal1 * Speed), (vertical1 * Speed));
    }

}