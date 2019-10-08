using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuFunc : MonoBehaviour
{
    public GameObject confirminMenu;
    public GameObject howToPlayMenu;
    public GameObject mainMenu;
    public PlayerData scores;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;
    public TextMeshProUGUI score4;
    public TextMeshProUGUI score5;

    private void Start()
    {
        UpdateScoreboardData(scores);
        confirminMenu.SetActive(false);
        howToPlayMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    private void UpdateScoreboardData(PlayerData scores)
    {
        scores = SaveData.LoadPlayer();
        if (scores != null)
        {
            score1.text = "1: " + scores.score1;
            score2.text = "2: " + scores.score2;
            score3.text = "3: " + scores.score3;
            score4.text = "4: " + scores.score4;
            score5.text = "5: " + scores.score5;
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OpenHowToPlay()
    {
        howToPlayMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CloseHowToPlay()
    {
        howToPlayMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Quitting.");
        Application.Quit();
    }

    public void OpenConfirmation()
    {
        confirminMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CloseConfirmation()
    {
        confirminMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
