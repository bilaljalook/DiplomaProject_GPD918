using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    //TODO complete the animation proccess for the explosion effect

    public float speed = 1f;
    public Rigidbody2D rigid;
    //public GameObject explosionEffect;

    // Use this for initialization
    void Start()
    {
        rigid.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TankBlueprint Tank = collision.GetComponent<TankBlueprint>();
        if (Tank!=null)
        {
            Tank.TakeDamage(1);
        }
        Debug.Log(collision.name);
        //Instantiate(explosionEffect, transform.position, transform.rotation);
        
        Destroy(gameObject);
        
    }
}

    
