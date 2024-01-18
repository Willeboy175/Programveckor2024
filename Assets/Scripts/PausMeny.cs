using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PausMeny : MonoBehaviour
{
    [SerializeField]
    private GameObject _PausMeny;
    public static bool isPaused;
    public AudioSource Click;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  //När man trycker på "escape" dyker paus menyn upp och tiden fryser
        {
            if (isPaused == true) //om spelet redan är pausat när man trycker "escape" så startar det igen.
            {
                ResumeButton();
                Click.Play();
            }
            else // annars pausas det
            {
                PauseGame();
                Click.Play();
            }
            
        }
    }
    public void ResumeButton()  //Om man trycker på resume-knappen eller "escape" börjar tiden gå igen samt paus menyn stängs
    {
        isPaused = false;
        Time.timeScale = 1f;
        _PausMeny.SetActive(false);
        Click.Play();
    }
    public void PauseGame() //när spelet är pausat aktiveras paus-menyn.
    {
        isPaused = true;
        Time.timeScale = 0f;
        _PausMeny.SetActive(true);
        Click.Play();
    }
    public void Menu() // byter till huvudmeny-scenen
    {
        Click.Play();
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void Restart() // startar om scenen samt ändrar tillbaka tiden från 0 till 1
    {
        Click.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
