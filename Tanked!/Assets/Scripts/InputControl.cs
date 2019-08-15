using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InputControl : MonoBehaviour
{
    //references
    public EventSystem eventSystem;

    public GameObject selectedGameObject;

    private bool buttonSelected = false;

    public static bool GamePause = false;

    private void Update()
    {
        if (SceneManager.GetSceneByName("MainMenu").isLoaded)//restart score when game is finished
        {
            ScoreSystem.score1 = 0;
            ScoreSystem.score2 = 0;
        }
        if (Input.GetAxisRaw("Vertical") != 0 && Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)//selection navigation
        {
            eventSystem.SetSelectedGameObject(selectedGameObject);
            buttonSelected = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))//Pause menu start
        {
            if (GamePause)
            {
                Resume();
            }
            else
            {
                if (PlayerController.stopInput == false)// can pause if the game is started
                {
                    PlayerController.stopInput = true; //pause any player movement during pause menu control
                    Pause();
                    //eventSystem.SetSelectedGameObject(null); //reseting selection to fix bug for animation button highlgihts
                    //eventSystem.SetSelectedGameObject(eventSystem.firstSelectedGameObject);
                }
            }
        }
    }

    private void Pause()
    {
        selectedGameObject.SetActive(true);

        Time.timeScale = 0f;
        GamePause = true;
    }

    public void Resume()
    {
        PlayerController.stopInput = false;
        selectedGameObject.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
    }

    private void OnDisable()
    {
        buttonSelected = false;
    }

    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitButton()
    {
        Application.Quit();
        //Debug.Log("You quit the game");
    }

    public void LoadMain(string Main)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Main);
    }

    public void FullScreen(bool isFull)
    {
        if (isFull)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }
}