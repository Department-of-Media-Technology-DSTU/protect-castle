using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseGameMenu;
    public GameObject gameMode;

    public void Resum()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        gameMode.SetActive(true);
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        gameMode.SetActive(false);
    }

    public void LosdMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Again()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
}
