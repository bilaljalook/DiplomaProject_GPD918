﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InputControl : MonoBehaviour
{
    //TODO transfer all ButtonControl related object in the engine to Input control
    public EventSystem eventSystem;
    public GameObject selectedGameObject;

    private bool buttonSelected=false;

    public static bool GamePause = false;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxisRaw("Vertical")!=0 && buttonSelected==false)
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
                Pause();
            }
        }
        /*if (gOver.health==0)
        {
            SceneManager.LoadScene("GameOver");
        }*/
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
        Debug.Log("You quit the game");
    }

    public void LoadMain(string Main)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Main);
    }
}
