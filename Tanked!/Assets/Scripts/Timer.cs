using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    //Referencing Timer for PowerUp
    [SerializeField] private Slider pTimer;

    [SerializeField] private GameObject player;

    private float startTimer = 0;

    private bool fillStart = false;

    private void Start()
    {
        pTimer = GetComponent<Slider>();
        GetComponent<GameObject>();
        player.GetComponent<PlayerController>();
        GameObject p = player.GetComponent<GameObject>();
    }

    private void Update()
    {
        if (fillStart == true)
        {
            fillTime();
        }
    }

    public void FillTimer()
    {
        fillStart = true;
    }

    private void stoptimer()
    {
        fillStart = false;
    }

    private void fillTime()
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