using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BricksWallsBase : MonoBehaviour {
    //get the star to bes destroyed corectly and go to the next scene, connect it with the score system
    [SerializeField] GameObject Star;
    //Collider2D col;
    InputControl scene;
   
	// Use this for initialization
	void Start () {
        scene = FindObjectOfType<InputControl>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void BlockDestroyed()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Collider2D col;
        projectile projectile = collision.GetComponent<projectile>();

        Debug.Log("Star Col//: " + collision.gameObject.tag);
        BlockDestroyed();
        if (gameObject.name=="star")
        {
            SceneManager.LoadScene(2);
        }
 
    }

}
