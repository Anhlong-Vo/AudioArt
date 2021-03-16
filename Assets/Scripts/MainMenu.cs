using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
