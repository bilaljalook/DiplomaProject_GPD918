using UnityEngine;
using UnityEngine.UI;

//to call the slider of slider and savit it for audio control
public class GetVolValue : MonoBehaviour
{
    [SerializeField] private Slider vSlide;

    private void Start()
    {
        vSlide.GetComponent<Slider>();
        vSlide.value = AudioControl.saveVol;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}