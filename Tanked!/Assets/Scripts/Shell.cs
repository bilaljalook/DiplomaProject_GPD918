using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

    [SerializeField] Transform BarrelPoint;
    [SerializeField] GameObject ProPre;
    
    //[SerializeField] public GameObject ShooterPlayer;
    public bool SelectShooter;
    
    // Update is called once per frame
    void Update () {
        
	}
    public void Shoot()
    {
        
        Instantiate(ProPre, BarrelPoint.position, BarrelPoint.rotation);
        FindTheShooter();
    }
    void FindTheShooter()
    {
        
        Transform par = BarrelPoint.parent;

        if (par.CompareTag("Player1")==true)
        {
            if (GameObject.FindGameObjectWithTag("Star")==true)
            {
                SelectShooter = true;

            }
        }
        else if (par.CompareTag("Player2")==true)
        {

            if (GameObject.FindGameObjectWithTag("Star") == true)
            {
                SelectShooter = false;

            }
        }
    }
   
}
