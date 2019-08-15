using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDestroy : MonoBehaviour
{
    //references
    [SerializeField] private Animation explodingEffect;


    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) //destroy and call audio and animation
    {
        projectile projectile = collision.GetComponent<projectile>();

        if (collision.name == ("Projectile 1(Clone)"))
        {
            AudioControl.instance.Play("bHit");

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject);
            explodingEffect.GetComponent<Animation>();
            explodingEffect = Instantiate(explodingEffect, transform.position, transform.rotation);
            
        }
        //Debug.Log("Brick//: " + collision.name);
    }
}
