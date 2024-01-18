using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool isStart;
    public bool isQuit;
    public AudioSource Click;

    public void PlayGame()
    {
        if (isStart)
        {
            Click.Play();         
            SceneManager.LoadScene(2); // �ppnar spel-scenen

        }
        if (isQuit)
        {
            Application.Quit(); // st�nger ner programmet (n�r det �r en build)
        }
    }
}
