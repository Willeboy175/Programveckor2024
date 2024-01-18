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
            SceneManager.LoadScene(2); // Öppnar spel-scenen

        }
        if (isQuit)
        {
            Application.Quit(); // stänger ner programmet (när det är en build)
        }
    }
}
