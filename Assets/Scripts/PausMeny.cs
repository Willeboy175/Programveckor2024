using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PausMeny : MonoBehaviour
{
    [SerializeField]
    private GameObject _PausMeny;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  //När man trycker på "escape" dyker paus menyn upp och tiden fryser
        {
            if (isPaused == true)
            {
                ResumeButton();
            }
            else
            {
                PauseGame();
            }
            
        }
    }
    public void ResumeButton()  //Om man trycker på "resume" knappen börjar tiden gå igen samt paus menyn stängs
    {
        isPaused = false;
        Time.timeScale = 1f;
        _PausMeny.SetActive(false);
    }
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        _PausMeny.SetActive(true);
    }
    public void Menu()
    {
        SceneManager.LoadScene(1);
    }

}
