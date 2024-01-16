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
        if (movementKeyPressed)
        {
            if (other.tag == "Ground" && !Running.isPlaying)
            {
                Running.volume = Random.Range(0.5f, 0.7f);
                Running.pitch = Random.Range(0.95f, 1.05f);
                Running.Play();
            }
        }

        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (movementKeyPressed == false)
        {
            //Kollar om kollisionen är med ett object som har tagen Ground har den det så slutar den spela ljudet
            if (other.tag == "Ground" && Running.isPlaying)
            {
                print("Stop");
                Running.Stop();
            }
           
        }
    }
    void Update()
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

