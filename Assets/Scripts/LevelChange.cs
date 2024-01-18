using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    // byter scene och nivå med scenemanager. 
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}