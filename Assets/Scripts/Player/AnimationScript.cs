using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    // Variabler för Rigidbody, spelarobjekt och Animator
    public Rigidbody2D rb; // Rigidbody för att hantera fysik på objektet
    public GameObject Player; // Spelarobjektet
    public Animator animator; // Animator för att styra animationer

    void Start()
    {
        // Hämtar komponenter vid start
        animator = GetComponent<Animator>(); // Hämtar Animator-komponenten från objektet
        rb = GetComponent<Rigidbody2D>(); // Hämtar Rigidbody-komponenten från objektet
    }

    void Update()
    {
        // Kontrollerar om spelaren trycker ned rörelsetangenter (A, D, vänster pil, höger pil)
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("move", true); // Sätter boolen "move" till true i Animator-kontrollen
        }
        else
        {
            animator.SetBool("move", false); // Sätter boolen "move" till false i Animator-kontrollen om ingen rörelsetangent är nedtryckt
        }

        // Kontrollerar om spelaren trycker på hoppknappen (Space)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("jump"); // Aktiverar "jump"-trigger i Animator-kontrollen för att starta hoppanimationen
        }
    }
}