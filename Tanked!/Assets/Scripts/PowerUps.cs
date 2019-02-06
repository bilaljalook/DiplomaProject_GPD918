using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {
//TODO the animation need to stop looping
//TODO make the declarations of the script private for the ones you dont need
    public GameObject effect;
    public float speedUp = 2;
    public float rateSpeed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("PowerUpSpeed"))
        {

            if (collision.CompareTag("Player1") ) 
            {
            
                StartCoroutine(PickPowerSpeed(collision));
           
            }
            else if (collision.CompareTag("Player2"))
            {
                StartCoroutine(PickPowerSpeed1(collision));
            }
        }
        else if (gameObject.CompareTag("PowerUpRate"))
        {
            if (collision.CompareTag("Player1"))
            {

                StartCoroutine(PickPowerRate(collision));
            }
            else if (collision.CompareTag("Player2"))
            {
                StartCoroutine(PickPowerRate1(collision));
            }
        }
    }

    IEnumerator PickPowerSpeed(Collider2D player)
    {
        Instantiate(effect, transform.position, transform.rotation);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        PlayerController player1 = player.GetComponent<PlayerController>();
        player1.Speed += speedUp;

        yield return new WaitForSeconds(2);
        player1.Speed -= speedUp;

        Destroy(gameObject);
    }
    IEnumerator PickPowerSpeed1(Collider2D player1)
    {
        Instantiate(effect, transform.position, transform.rotation);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;


        PlayerController2 player2 = player1.GetComponent<PlayerController2>();
        player2.Speed += speedUp;

        yield return new WaitForSeconds(2);
        player2.Speed -= speedUp;
        Destroy(gameObject);
    }
    IEnumerator PickPowerRate(Collider2D player)
    {
        Instantiate(effect, transform.position, transform.rotation);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        PlayerController player1 = player.GetComponent<PlayerController>();
        player1.RateOfFire -= rateSpeed;

        yield return new WaitForSeconds(2);
        player1.RateOfFire += rateSpeed;

        Destroy(gameObject);
    }
    IEnumerator PickPowerRate1(Collider2D player1)
    {
        Instantiate(effect, transform.position, transform.rotation);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        PlayerController2 player2 = player1.GetComponent<PlayerController2>();
        player2.RateOfFire -= rateSpeed;

        yield return new WaitForSeconds(2);
        player2.RateOfFire += rateSpeed;
        Destroy(gameObject);
    }
}
