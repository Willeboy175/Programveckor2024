using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSounds : MonoBehaviour
{
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode right;

    public bool movementKeyPressed;

    public AudioSource Running;

    void OnTriggerStay2D(Collider2D other)
    {
        if (movementKeyPressed == true)// Om A eller D är nedtryckt ska den spela upp ljudet från den tillagda AudioSourcen
        {
            if (other.tag == "Ground" && !Running.isPlaying)
            {
                Running.volume = Random.Range(0.3f, 0.5f);
                Running.pitch = Random.Range(0.95f, 1.05f);
                Running.Play();
            }          
        }
        if (movementKeyPressed == false)// Om A eller D inte är nedtryckta ska den sluta spela upp ljudet.
        {
            if (other.tag == "Ground")
            {
                print("Stop");
                Running.Stop();
            }  

        }
    }
    void OnTriggerExit2D(Collider2D other)// Om boxkollidern slutar vara i kontakt med Triggern ska den sluta spela ljudet
    {
        if (movementKeyPressed)
        {
            
            if (other.tag == "Ground")
            {
                print("Stop");
                Running.Stop();
            }
        }
    }
    void Update() // Kollar om A eller D är nedtryckt
    {
        if (Input.GetKey(left) || Input.GetKey(right))
        {
            movementKeyPressed = true;
        }
        else
        {
            movementKeyPressed = false;
        }
    }
}

