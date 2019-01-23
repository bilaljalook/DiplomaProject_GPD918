using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

    public Transform BarrelPoint;
    public GameObject ProPre;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
	}
    void Shoot()
    {
        
        Instantiate(ProPre, BarrelPoint.position, BarrelPoint.rotation);
    }
}
