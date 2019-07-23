using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    private Resolution[] resolution;
    public Dropdown resDrop;

    private void Start()
    {
        ResolutionList();
    }

    private void ResolutionList()
    {
        resolution = Screen.resolutions;

        resDrop.ClearOptions();

        List<string> opt = new List<string>();

        int ResIndex = 0;

        for (int i = 0; i < resolution.Length; i++)
        {
            string option = resolution[i].width + " x " + resolution[i].height + " " + resolution[i].refreshRate + "Hz";

            if (opt.Contains(option) == false)
            {
                opt.Add(option);
            }

            if (resolution[i].Equals(Screen.currentResolution) && resolution[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                ResIndex = i;
            }
        }
        resDrop.AddOptions(opt);
        resDrop.value = ResIndex;
        resDrop.RefreshShownValue();
    }

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

    public void SetRes(int resIndex)
    {
        Resolution res = resolution[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen, res.refreshRate);
    }
}