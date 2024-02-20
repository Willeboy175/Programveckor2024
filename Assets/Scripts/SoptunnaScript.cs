using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoptunnaScript : MonoBehaviour
{
    // Variabler f�r att hantera trash can-interaktion
    public bool isInTrashCan = false; // Variabel som indikerar om spelaren f�r n�rvarande �r i soptunnan
    public float interactionRadius = 2f; // Radie inom vilken spelaren kan interagera med soptunnan
    public LayerMask playerLayer; // Layer mask f�r att filtrera spelare f�r interaktion
    public GameObject interactionText; // Text som visas n�r spelaren �r n�ra soptunnan

    // Referenser till andra script och objekt
    private PlayerMovementScript playerMovement;
    private RotateAroundPlayer gun;
    private bool playerWithGun = true;

    // Metod som ritar en gizmo f�r att visa interaktionsradien i Unity-editorn
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

    void Update()
    {
        // Kolla om spelare �r inom interaktionsradien
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, interactionRadius, playerLayer);

        if (colliders != null)
        {
            // Visa interaktionstext
            interactionText.SetActive(true);

            if (playerMovement == null)
            {
                // H�mta referenser till spelarobjektet och dess vapen
                playerMovement = colliders.GetComponent<PlayerMovementScript>();

                try
                {
                    gun = playerMovement.GetComponentInChildren<RotateAroundPlayer>();
                }
                catch (System.Exception)
                {
                    throw;
                }

                if (gun == null)
                {
                    playerWithGun = false;
                }
            }

            // Kolla om spelaren finns och om interaktionsknappen (E) trycks ned
            if (playerMovement != null && Input.GetKeyDown(KeyCode.E))
            {
                InteractWithTrashcan(playerMovement, gun);
            }
        }
        else if (playerMovement != null && Input.GetKeyDown(KeyCode.E) && isInTrashCan == true)
        {
            ExitTrashcan(playerMovement, gun);
        }
        else
        {
            // G�m interaktionstext om ingen spelare �r inom r�ckvidd
            interactionText.SetActive(false);
        }
    }
    // Metod f�r att interagera med soptunnan
    void InteractWithTrashcan(PlayerMovementScript playerMovement, RotateAroundPlayer gun)
    {
        Debug.Log("Entering the trash can");
        // H�mta relevanta komponenter fr�n spelaren
        SpriteRenderer playerSpriteRenderer = playerMovement.GetComponent<SpriteRenderer>();
        Rigidbody2D playerRigidBody2D = playerMovement.GetComponent<Rigidbody2D>();

        if (playerRigidBody2D != null)  // Stoppa r�relse f�r spelaren n�r hen �r i soptunnan
        {
            playerRigidBody2D.simulated = false;
            playerRigidBody2D.velocity = Vector2.zero;
        }
        if (playerSpriteRenderer != null)   // D�lj spelarens sprite
        {
            playerSpriteRenderer.enabled = false;
        }
        // Om spelaren har ett vapen
        if (playerWithGun)
        {
            Shoot shoot = playerMovement.GetComponent<Shoot>();
            SpriteRenderer gunSprite = gun.GetComponent<SpriteRenderer>();

            if (gunSprite != null) // D�lj vapnets sprite
            {
                gunSprite.enabled = false;
            }
            if (shoot != null) // Avaktivera skript f�r skjutning
            {
                shoot.enabled = false;
            }
        }
        isInTrashCan = !isInTrashCan;  // �ndra isInTrashCan-variabeln
    }

    // Funktion f�r att l�mna soptunnan
    void ExitTrashcan(PlayerMovementScript playerMovement, RotateAroundPlayer gun)
    {
        Debug.Log("Exiting the trash can");
        // H�mta relevanta komponenter fr�n spelaren
        SpriteRenderer playerSpriteRenderer = playerMovement.GetComponent<SpriteRenderer>();
        Rigidbody2D playerRigidBody2D = playerMovement.GetComponent<Rigidbody2D>();

        if (playerRigidBody2D != null)  // Aktivera gravitation f�r spelaren n�r man l�mnar soptunnan
        {
            playerRigidBody2D.simulated = true;
            playerRigidBody2D.velocity = Vector2.zero;
        }
        if (playerSpriteRenderer != null)   // Visa spelarens sprite igen
        {
            playerSpriteRenderer.enabled = true;
        }

        // Om spelaren har ett vapen
        if (playerWithGun)
        {
            Shoot shoot = playerMovement.GetComponent<Shoot>();
            SpriteRenderer gunSprite = gun.GetComponent<SpriteRenderer>();

            if (gunSprite != null) // Visa vapnets sprite
            {
                gunSprite.enabled = true;
            }
            if (shoot != null) // Aktivera skript f�r skjutning
            {
                shoot.enabled = true;
            }
        }
        isInTrashCan = false;  // �terst�ll isInTrashCan-variabeln till false
    }
}