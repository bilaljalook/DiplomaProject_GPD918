using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour {
    //TODO need find a way to reference the point system to detect the kill to increase the score
    [SerializeField] TextMeshProUGUI TextP1;
    [SerializeField] TextMeshProUGUI TextP2;

    public GameObject P1;
    public GameObject P2;

    int score1;
    int score2;

    string P1s = "P1 : ";
    string P2s = "P2 : ";

    bool update=false ;

    // Use this for initialization
    void Start()
    {
        TextP1.text = P1s + score1.ToString();
        TextP2.text = P2s + score2.ToString();
        //AddPts();
        
        // P1 = GetComponent<TankBlueprint>().Tank;
        // P2 = GetComponent<TankBlueprint>().Tank;
    }

    // Update is called once per frame
    void Update()
    {
        if (!update)
        {
            AddPts();
        /*
        if (GameObject.FindGameObjectWithTag("Player2") == null)
        {
            score1 = score1 + 1;
            update = true;
        }
        if (GameObject.FindGameObjectWithTag("Player1") == null)
        {
            score2 += 1;
            update = true;
        }
        TextP1.text = P1s + score1.ToString();
        TextP2.text = P2s + score2.ToString();*/
        }
    }
    public void AddPts()
    {
        
        if (GameObject.FindGameObjectWithTag("Player2") == null)
        {
            score1=score1+1;
            update = true;
        }
        if (GameObject.FindGameObjectWithTag("Player1") == null)
        {
            score2+=1;
            update = true;
        }
        TextP1.text = P1s + score1.ToString();
        TextP2.text = P2s + score2.ToString();
        
    }
}
