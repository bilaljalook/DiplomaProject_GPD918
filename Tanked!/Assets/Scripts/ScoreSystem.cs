using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour {
   
    [SerializeField] TextMeshProUGUI TextP1;
    [SerializeField] TextMeshProUGUI TextP2;
    [SerializeField] TextMeshProUGUI winner;

    public GameObject P1;
    public GameObject P2;

    public int score1;
    public int score2;

    string P1s = "P1 : ";
    string P2s = "P2 : ";


    bool update=false ;

    // Use this for initialization
    void Start()
    {
        TextP1.text = P1s + score1.ToString();
        TextP2.text = P2s + score2.ToString();
        winner.text = winner.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!update)
        {
            AddPts();
        }
        Scoreboared();
    }
    public void AddPts()
    {
        PlayerPrefs.GetInt("p1");
        PlayerPrefs.GetInt("p2");
        if (GameObject.FindGameObjectWithTag("Player2") == null)
        {
            score1=score1+1;
            update = true;
            PlayerPrefs.SetInt("p2", score2);
        }
        if (GameObject.FindGameObjectWithTag("Player1") == null)
        {
            score2+=1;
            update = true;
            PlayerPrefs.SetInt("p1", score1);
        }
        TextP1.text = P1s + score1.ToString();
        TextP2.text = P2s + score2.ToString();
       
    }
    private void Awake()
    {
        
        
    }
    public void Scoreboared()
    {
        string w1 = "player 1 is the winner!!";
        string w2 = "player 2 is the winner!!";
        if (score1>score2)
        {
            winner.text = w1.ToString();
        }
        else if (score2> score1)
        {
            winner.text = w2.ToString();
        }
        else
        {
            winner.text = "no one won";
        }
    }

    public void saveScore()
    {
        PlayerPrefs.SetInt("p1", score1);
        PlayerPrefs.SetInt("p2", score2);
    }
    
}
