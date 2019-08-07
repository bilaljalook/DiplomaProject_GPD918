using UnityEngine;

public class Coundown : MonoBehaviour
{
    //Setting the class to use in the animation when finished
    private GameManager GmCountD;

    public void SetCountD()
    {
        GmCountD = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameManager.Countdown = true;
        PlayerController.stopInput = false;
        Destroy(gameObject);
    }
}