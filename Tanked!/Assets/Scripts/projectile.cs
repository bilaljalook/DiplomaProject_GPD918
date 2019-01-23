using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{


    public float speed = 1f;
    public Rigidbody2D rigid;

    // Use this for initialization
    void Start()
    {
        rigid.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        //Destroy(gameObject);
    }
}

    
