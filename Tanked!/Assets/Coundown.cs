using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coundown : MonoBehaviour
{
    //Setting the class to use in the animation when finished
    GameManager GmCountD;
   
    public void SetCountD()
    {
        GmCountD = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameManager.Countdown = true;
        PlayerController.stopInput = false;
    }
}
