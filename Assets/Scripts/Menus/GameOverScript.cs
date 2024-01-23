using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverPanel;
    //Kod som är gjord för att knapparna ska ladda olika scener när man dött
    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}