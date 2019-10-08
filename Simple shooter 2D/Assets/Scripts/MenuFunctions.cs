using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    public GameObject deadMenu;
    public GameObject pauseMenu;
    public PlayerController player;
    private bool active;

    private void Start()
    {
        active = false;
        deadMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && player.life != 0)
        {
            if (!active) OpenPauseMenu();
            else ClosePauseMenu();
        }
    }

    public void Restart()
    {
        deadMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void OpenPauseMenu()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
