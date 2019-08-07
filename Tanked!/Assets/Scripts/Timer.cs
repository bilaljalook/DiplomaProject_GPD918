using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

        //Referencing Timer for PowerUp
    [SerializeField] Slider pTimer;
    [SerializeField] GameObject player;
    
    float startTimer = 0;
    
     bool fillStart = false;

    void Start()
    {
        pTimer=GetComponent<Slider>();
        GetComponent<GameObject>();
        player.GetComponent<PlayerController>();
        GameObject p=player.GetComponent<GameObject>();
       
    }

   
    void Update()
    {
        if (fillStart==true)
        {

            fillTime();
            
      
        }

    }       

    public void FillTimer()
    {
        fillStart=true;
    }
    void stoptimer()
    {
        fillStart = false;
       
    }
    void fillTime()
    {
       // Debug.Log("timeradding");
        pTimer.value += Time.deltaTime;
        if (pTimer.value == 3.0f)
        {
            
            pTimer.value = 0;
            stoptimer();

        }
    }

}
