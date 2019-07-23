using UnityEngine;

// this script will save the score of the game and other settings like the audio and key mapping , map generation and so on ......

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int scoreM1;
    public static int scoreM2;

    private void Awake()
    {
        if (Instance == null)

        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
    }

    private void KeepScore()
    {
    }
}