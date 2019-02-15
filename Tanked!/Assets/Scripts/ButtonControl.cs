using System.Collections;
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
            PlayerPrefs.DeleteAll();
        }

        public void LoadMain()
        {
        //PlayerPrefs.DeleteKey("p1");
        //PlayerPrefs.DeleteKey("p2");
            
        }


}
