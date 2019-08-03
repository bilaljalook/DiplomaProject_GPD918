using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

        //Referencing Timer for PowerUp
    [SerializeField] Slider pTimer;
    [SerializeField] GameObject PowerUp;
    PowerUps power;
    public float startTimer = 0;
    //[SerializeField] Slider pTimer;
     bool fillStart = false;

    void Start()
    {
        pTimer=GetComponent<Slider>();
       // power=power.GetComponent<PowerUps>();
        //PowerUp = power.GetComponent<GameObject>();
        
       // theSlide=GetComponent<GameObject>();
    }

   
    void Update()
    {
        if (fillStart==true)
        {

            fillTime();
            Debug.Log(PowerUp);
      
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
        // startTimer += Time.smoothDeltaTime;
        // pTimer.value = startTimer;
        Debug.Log("timeradding");
        pTimer.value += Time.deltaTime;
        if (pTimer.value == 3.0f)
        {
            //startTimer = 0;
            pTimer.value = 0;
            stoptimer();

        }
    }

}
