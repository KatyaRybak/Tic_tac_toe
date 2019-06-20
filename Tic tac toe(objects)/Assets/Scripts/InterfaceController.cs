using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InterfaceController : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public Button menuButton;
    public Text score1;
    public Text score2;
    public GameObject SelectPlayerPanel;

    public void ShowMenuPanel()
    {
        if (menuButton.transform.eulerAngles.z <= 181f&& menuButton.transform.eulerAngles.z>=179f)
        {
            menuPanel.SetActive(true);
            MainLogic.instance.isGamePaused = true;
        }
        else
        {
            menuPanel.SetActive(false);
            MainLogic.instance.isGamePaused = false;
        }
        menuButton.transform.Rotate(new Vector3(0,0,180));
    }

    public void ShowGameOverPanel(bool win, int winner)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = win?"Winner: " + (Side)winner : "Dead head";
        menuButton.gameObject.SetActive(false);
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);

    }

    public void RefreshScore()
    {
        if (score1.text != null)
        {
            score1.text = MainLogic.instance.score1.ToString();
            score2.text = MainLogic.instance.score2.ToString();
        }   
    }

    private void Start()
    {
        RefreshScore();
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowPlayersPanel()
    {
        SelectPlayerPanel.SetActive(true); 
    }

    public void SelectOnePlayer()
    {
        MainLogic.instance.isOnePlayer = true;
        SelectPlayerPanel.SetActive(false);
    }

    public void SelectTwoPlayers()
    {
        MainLogic.instance.isOnePlayer = false;
        SelectPlayerPanel.SetActive(false);
    }
}
