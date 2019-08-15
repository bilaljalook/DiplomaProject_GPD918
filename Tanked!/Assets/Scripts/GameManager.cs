using UnityEngine;

// this script for future use or refactoring purposes

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static bool Countdown = false;

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
}