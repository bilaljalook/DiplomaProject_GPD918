﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour {

   
        public void LoadSceneByIndex(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void QuitButton()
        {
            Application.Quit();
            Debug.Log("You quit the game");
        }



    
}