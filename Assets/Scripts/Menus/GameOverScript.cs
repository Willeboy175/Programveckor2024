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