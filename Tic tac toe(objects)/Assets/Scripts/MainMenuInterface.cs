using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuInterface : MonoBehaviour
{
    public GameObject optionsMenuPanel;
    public GameObject mainMenuPanel;
    public Dropdown optionSize;
    public Dropdown optionCrossed;

    public void OpenOptionsMenu()
    {
        optionsMenuPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        LoadSavedData();
    }

    private void LoadSavedData()
    {
        optionCrossed.value = PlayerPrefController.GetCrossedValue() - 3;
        optionSize.value = PlayerPrefController.GetSizeValue() - 3;
    }

    public void OpenMainMenu()
    {
        optionsMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
        
    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetSizeOption()
    {
        int index = optionSize.value;
        switch (index)
        {
            case 0:
                PlayerPrefController.SetSizeValue(3);
                break;
            case 1:
                PlayerPrefController.SetSizeValue(4);
                break;
            case 2:
                PlayerPrefController.SetSizeValue(5);
                break;
            case 3:
                PlayerPrefController.SetSizeValue(6);
                break;

        }
    }

    public void SetCrossedOption()
    {
        int index = optionCrossed.value;
        switch (index)
        {
            case 0:
                PlayerPrefController.SetCrossedValue(3);
                break;
            case 1:
                PlayerPrefController.SetCrossedValue(4);
                break;
            case 2:
                PlayerPrefController.SetCrossedValue(5);
                break;
        }
    }

    public void ExitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

    #else
        Application.Quit();
    #endif
    }
}
