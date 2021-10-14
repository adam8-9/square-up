using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Player1Select");
    }
    public void Options()
    {
        SceneManager.LoadScene("Controls");
    }

    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
