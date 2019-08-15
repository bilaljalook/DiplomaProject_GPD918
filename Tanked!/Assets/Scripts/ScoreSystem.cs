using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    //referencs
    [SerializeField] private TextMeshProUGUI TextP1;

    [SerializeField] private TextMeshProUGUI TextP2;
    [SerializeField] private TextMeshProUGUI winner;
    [SerializeField] private TextMeshProUGUI Rounds;

    public GameObject P1;
    public GameObject P2;

    public static int score1;
    public static int score2;

    private string P1s = "P1 : ";
    private string P2s = "P2 : ";
    private string round = "Round ";

    public static int rCount = 0;

    //initialization
    private void Start()
    {
        TextP1.text = P1s + score1.ToString();
        TextP2.text = P2s + score2.ToString();

        // Rounds.text = round + rCount.ToString()+"/3";

        winner.text = winner.ToString();
    }

    // Update is called once per frame
    private void Update()//updating score on screen
    {
        TextP1.text = P1s + score1.ToString();
        TextP2.text = P2s + score2.ToString();
        Scoreboared();
        Rounds.text = round + rCount.ToString() + "/3";
    }

    public void AddPtsP1() //add score to player 1
    {
        score1 = score1 + 1;
        Debug.Log("added 1");

        TextP1.text = P1s + score1.ToString();
    }

    public void AddPtsP2()//add score to player 2
    {
        score2 += 1;
        Debug.Log("added 2");

        TextP2.text = P2s + score2.ToString();
    }

    public void Scoreboared() //connecting scores to show on scoreboared scene
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

    public static void RoundCount() //count the rounds
    {
        rCount++;
        if (rCount == 3)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}