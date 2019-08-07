﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InputControl : MonoBehaviour
{  
    public EventSystem eventSystem;

    public GameObject selectedGameObject;

    private bool buttonSelected = false;

    public static bool GamePause = false;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (SceneManager.GetSceneByName("MainMenu").isLoaded)
        {
            ScoreSystem.score1 = 0;
            ScoreSystem.score2 = 0;
        }
        if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
        {
            eventSystem.SetSelectedGameObject(selectedGameObject);
            buttonSelected = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause)
            {
                Resume();
            }
            else
            {
                if (PlayerController.stopInput==false)
                {

                Pause();
                eventSystem.SetSelectedGameObject(null);
                eventSystem.SetSelectedGameObject(eventSystem.firstSelectedGameObject);
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