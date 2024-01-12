using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool isStart;
    public bool isQuit;

    public void PlayGame()
    {
        if (isStart)
        {
            SceneManager.LoadScene(2);

        }
        if (isQuit)
        {
            Application.Quit();
        }
    }
}
