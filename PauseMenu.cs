using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }   
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Menu()
    {
        SceneManager.LoadScene("main menu");
    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
