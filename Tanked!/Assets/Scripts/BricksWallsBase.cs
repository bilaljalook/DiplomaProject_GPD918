using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BricksWallsBase : MonoBehaviour {
    //get the star to bes destroyed corectly and go to the next scene, connect it with the score system
    [SerializeField] GameObject Star;

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
        projectile projectile = collision.GetComponent<projectile>();
        

         BlockDestroyed();
           
        if (gameObject.name=="star")
        {
            SceneManager.LoadScene(2);
        }
 
    }

}
