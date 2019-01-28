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
        /*if (collision.gameObject.tag=="Player2")
        {
            GetComponent<TankBlueprint>().Tank . GetComponent<TankBlueprint>().TakeDamage(1);
            
            //Destroy(collision.gameObject);
        }
        else if (GameObject.FindGameObjectWithTag("Player2")&&collision.gameObject)
        {
            gameObject.GetComponent<TankBlueprint>().TakeDamage();
            //Destroy(collision.gameObject);
        }*/
        TankBlueprint Tank = collision.GetComponent<TankBlueprint>();
        if (Tank!=null)
        {

            Tank.TakeDamage(1);
        }
        

        //GetComponent<TankBlueprint>().TakeDamage();
        Debug.Log(collision.name);
        Destroy(gameObject);
        
    }
}

    
