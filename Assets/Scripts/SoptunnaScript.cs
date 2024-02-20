using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoptunnaScript : MonoBehaviour
{
    // Variabler för att hantera trash can-interaktion
    public bool isInTrashCan = false; // Variabel som indikerar om spelaren för närvarande är i soptunnan
    public float interactionRadius = 2f; // Radie inom vilken spelaren kan interagera med soptunnan
    public LayerMask playerLayer; // Layer mask för att filtrera spelare för interaktion
    public GameObject interactionText; // Text som visas när spelaren är nära soptunnan

    // Referenser till andra script och objekt
    private PlayerMovementScript playerMovement;
    private RotateAroundPlayer gun;
    private bool playerWithGun = true;

    // Metod som ritar en gizmo för att visa interaktionsradien i Unity-editorn
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

    void Update()
    {
        // Kolla om spelare är inom interaktionsradien
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, interactionRadius, playerLayer);

        if (colliders != null)
        {
            // Visa interaktionstext
            interactionText.SetActive(true);

            if (playerMovement == null)
            {
                // Hämta referenser till spelarobjektet och dess vapen
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
            // Göm interaktionstext om ingen spelare är inom räckvidd
            interactionText.SetActive(false);
        }
    }
    // Metod för att interagera med soptunnan
    void InteractWithTrashcan(PlayerMovementScript playerMovement, RotateAroundPlayer gun)
    {
        Debug.Log("Entering the trash can");
        // Hämta relevanta komponenter från spelaren
        SpriteRenderer playerSpriteRenderer = playerMovement.GetComponent<SpriteRenderer>();
        Rigidbody2D playerRigidBody2D = playerMovement.GetComponent<Rigidbody2D>();

        if (playerRigidBody2D != null)  // Stoppa rörelse för spelaren när hen är i soptunnan
        {
            playerRigidBody2D.simulated = false;
            playerRigidBody2D.velocity = Vector2.zero;
        }
        if (playerSpriteRenderer != null)   // Dölj spelarens sprite
        {
            playerSpriteRenderer.enabled = false;
        }
        // Om spelaren har ett vapen
        if (playerWithGun)
        {
            Shoot shoot = playerMovement.GetComponent<Shoot>();
            SpriteRenderer gunSprite = gun.GetComponent<SpriteRenderer>();

            if (gunSprite != null) // Dölj vapnets sprite
            {
                gunSprite.enabled = false;
            }
            if (shoot != null) // Avaktivera skript för skjutning
            {
                shoot.enabled = false;
            }
        }
        isInTrashCan = !isInTrashCan;  // Ändra isInTrashCan-variabeln
    }

    // Funktion för att lämna soptunnan
    void ExitTrashcan(PlayerMovementScript playerMovement, RotateAroundPlayer gun)
    {
        Debug.Log("Exiting the trash can");
        // Hämta relevanta komponenter från spelaren
        SpriteRenderer playerSpriteRenderer = playerMovement.GetComponent<SpriteRenderer>();
        Rigidbody2D playerRigidBody2D = playerMovement.GetComponent<Rigidbody2D>();

        if (playerRigidBody2D != null)  // Aktivera gravitation för spelaren när man lämnar soptunnan
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
            if (shoot != null) // Aktivera skript för skjutning
            {
                shoot.enabled = true;
            }
        }
        isInTrashCan = false;  // Återställ isInTrashCan-variabeln till false
    }
}