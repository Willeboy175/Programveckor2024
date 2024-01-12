using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverPanel;
    //Kod som �r gjord f�r att knapparna ska ladda olika scener n�r man d�tt
    public void LoadMenu()
    {
        SceneManager.LoadScene("Edvins Scen");
    }
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}