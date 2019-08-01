using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

        //Referencing Timer for PowerUp
    [SerializeField] Slider pTimer;
    //[SerializeField] Slider pTimer;

    float startingTime = 3f;


    void Start()
    {
        pTimer = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //startingTime -= Time.deltaTime;
        //pTimer.value -= Time.deltaTime; //startingTime;

    }       

    public void PowerUpTimerFire()
    {
        //slideFire.SetActive(true);
        //pTimerFire.value = 3;//Mathf.MoveTowards(pTimerFire.value, 3.0f, 0f);
        //if (pTimer.value == 0)
        //{
        //    slideFire.SetActive(false);
        //}

    }
    public void PowerUpTimerSpeed()
    {
        //slideFire.SetActive(true);
        //pTimerSpeed.value = Mathf.MoveTowards(pTimerFire.value, 3.0f, 0f);
        //if (pTimer.value == 0)
        //{
        //    slideFire.SetActive(false);
        //}

    }
}
