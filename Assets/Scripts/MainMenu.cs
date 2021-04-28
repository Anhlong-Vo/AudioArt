using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject spawner;
    public GameObject canvas;

    public void PlayGame()
    {
        canvas.SetActive(false);
        spawner.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("VR");
    }

    public void Continue()
    {
        SongManager.paused = false;
        
    }
}
