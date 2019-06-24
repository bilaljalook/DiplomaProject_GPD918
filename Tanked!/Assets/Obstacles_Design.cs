using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles_Design : MonoBehaviour {

    //TODO hier where all the walls and obstacles goes, plus try to generate the map aswell
    //[SerializeField] GameObject Bricks;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void BrickDestroyed()
    {
        
        Destroy(gameObject);
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        projectile pro = collision.gameObject.GetComponent<projectile>();
        
            Debug.Log(collision);
    }

}
