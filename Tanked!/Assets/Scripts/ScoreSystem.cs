using TMPro;
using UnityEngine;

//TODO Change the scoring system and add a game manager to save the score on it.
public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextP1;
    [SerializeField] private TextMeshProUGUI TextP2;
    [SerializeField] private TextMeshProUGUI winner;


   // public GameManager scoreManager1;
   // public GameManager scoreManager2;

    public GameObject P1;
    public GameObject P2;

    public static int score1;
    public static int score2;

    private string P1s = "P1 : ";
    private string P2s = "P2 : ";

    // Use this for initialization
    private void Start()
    {
        TextP1.text = P1s + score1.ToString();
        TextP2.text = P2s + score2.ToString();

       
       
        winner.text = winner.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        TextP1.text = P1s + score1.ToString();
        TextP2.text = P2s + score2.ToString();
        Scoreboared();
    }

    public void AddPtsP1()
    {
        score1 = score1 + 1;
        //Debug.Log("added 1");

        TextP1.text = P1s + score1.ToString();
    }

    public void AddPtsP2()
    {
        score2 += 1;
        //Debug.Log("added 2");

        TextP2.text = P2s + score2.ToString();
    }

    private void OnDestroy()
    {
        saveScore();
    }

    public void Scoreboared()
    {
        string w1 = "Player 1 is the winner!!";
        string w2 = "Player 2 is the winner!!";
        if (score1 > score2)
        {
            winner.text = w1.ToString();
        }
        else if (score2 > score1)
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
       

       

        //PlayerPrefs.SetInt("p1", score1);
        //PlayerPrefs.SetInt("p2", score2);
        //Debug.Log("Save");
    }

    public void OnApplicationQuit()
    {
       // PlayerPrefs.DeleteAll();
    }
}