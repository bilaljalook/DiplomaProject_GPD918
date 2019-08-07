using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetVolValue : MonoBehaviour
{
    [SerializeField] Slider vSlide;
    void Start()
    {
        vSlide.GetComponent<Slider>();
        vSlide.value = AudioControl.saveVol;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
