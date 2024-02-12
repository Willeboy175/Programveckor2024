using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    // Variabler f�r Rigidbody, spelarobjekt och Animator
    public Rigidbody2D rb; // Rigidbody f�r att hantera fysik p� objektet
    public GameObject Player; // Spelarobjektet
    public Animator animator; // Animator f�r att styra animationer

    void Start()
    {
        // H�mtar komponenter vid start
        animator = GetComponent<Animator>(); // H�mtar Animator-komponenten fr�n objektet
        rb = GetComponent<Rigidbody2D>(); // H�mtar Rigidbody-komponenten fr�n objektet
    }

    void Update()
    {
        // Kontrollerar om spelaren trycker ned r�relsetangenter (A, D, v�nster pil, h�ger pil)
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("move", true); // S�tter boolen "move" till true i Animator-kontrollen
        }
        else
        {
            animator.SetBool("move", false); // S�tter boolen "move" till false i Animator-kontrollen om ingen r�relsetangent �r nedtryckt
        }

        // Kontrollerar om spelaren trycker p� hoppknappen (Space)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("jump"); // Aktiverar "jump"-trigger i Animator-kontrollen f�r att starta hoppanimationen
        }
    }
}