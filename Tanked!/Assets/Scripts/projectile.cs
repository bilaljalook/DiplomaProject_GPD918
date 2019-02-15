using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class projectile : MonoBehaviour
{
    //TODO complete the animation proccess for the explosion effect

    [SerializeField] float speed = 1f;
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
        //par.transform.parent = obj.transform;
        //Debug.Log(collision+"projectile*****");
        if (Tank!=null)
        {
            Tank.TakeDamage(1);
        }
        //Debug.Log(gameObject);
        
        if (collision.name == ("star") )
        {
            
            
            if (FindObjectOfType<Shell>().SelectShooter==true)

            {
                FindObjectOfType<ScoreSystem>().AddPtsP1();
            }
            else if (FindObjectOfType<Shell>().SelectShooter == false)
            {
                FindObjectOfType<ScoreSystem>().AddPtsP2();
            }
           

        }
        
        //Instantiate(explosionEffect, transform.position, transform.rotation);

        Destroy(gameObject);
        
    }
}

    
