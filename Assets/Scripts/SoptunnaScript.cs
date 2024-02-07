using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoptunnaScript : MonoBehaviour
{
    public bool isInTrashCan = false; // Variable indicating whether the player is currently in the trash can
    public float interactionRadius = 2f; // Radius within which the player can interact with the trash can
    public LayerMask playerLayer; // Layer mask to filter players for interaction
    public GameObject interactionText; //Text will appear when the player is close to the trashcan

    private PlayerMovementScript playerMovement;
    private RotateAroundPlayer gun;
    private bool playerWithGun = true;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

    void Update()
    {
        // Check for players within the interaction radius
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, interactionRadius, playerLayer);

        if (colliders != null)
        {
            interactionText.SetActive(true);

            if (playerMovement == null)
            {
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

            // Check if the playerMovement component is not null && Check if the interaction key (E) is pressed
            if (playerMovement != null && Input.GetKeyDown(KeyCode.E))
            {
                InteractWithTrashcan(playerMovement, gun);
            }        
        }
        else if (playerMovement != null && Input.GetKeyDown(KeyCode.E))
        {
            ExitTrashcan(playerMovement, gun);
        }
        else
        {
            interactionText.SetActive(false);
        }
    }

    void InteractWithTrashcan(PlayerMovementScript playerMovement, RotateAroundPlayer gun)
    {
        Debug.Log("Entering the trash can");
        // Get relevant components from the player
        SpriteRenderer playerSpriteRenderer = playerMovement.GetComponent<SpriteRenderer>();
        Rigidbody2D playerRigidBody2D = playerMovement.GetComponent<Rigidbody2D>();

        if (playerRigidBody2D != null)  // Disable movement for the player when in the trash can
        {
            playerRigidBody2D.simulated = false;
            playerRigidBody2D.velocity = Vector2.zero;
        }
        if (playerSpriteRenderer != null)   // Toggle the visibility of the player's sprite
        {
            playerSpriteRenderer.enabled = false;
        }

        // If player has no gun
        if (playerWithGun)
        {
            Shoot shoot = playerMovement.GetComponent<Shoot>();
            SpriteRenderer gunSprite = gun.GetComponent<SpriteRenderer>();

            if (gunSprite != null) // Toggle player's gunSprite
            {
                gunSprite.enabled = false;
            }
            if (shoot != null) // Toggle shooting script
            {
                shoot.enabled = false;
            }
        }
        
        isInTrashCan = !isInTrashCan;  // Toggle the isInTrashCan variable
    }

    void ExitTrashcan(PlayerMovementScript playerMovement, RotateAroundPlayer gun)
    {
        Debug.Log("Exiting the trash can");
        // Get relevant components from the player
        SpriteRenderer playerSpriteRenderer = playerMovement.GetComponent<SpriteRenderer>();
        Rigidbody2D playerRigidBody2D = playerMovement.GetComponent<Rigidbody2D>();

        if (playerRigidBody2D != null)  // Enable gravity for the player when exiting the trash can
        {
            playerRigidBody2D.simulated = true;
            playerRigidBody2D.velocity = Vector2.zero;
        }
        if (playerSpriteRenderer != null)   // Toggle the visibility of the player's sprite
        {
            playerSpriteRenderer.enabled = true;
        }

        // If player has no gun
        if (playerWithGun)
        {
            Shoot shoot = playerMovement.GetComponent<Shoot>();
            SpriteRenderer gunSprite = gun.GetComponent<SpriteRenderer>();

            if (gunSprite != null) // Toggle player's gunSprite
            {
                gunSprite.enabled = true;
            }
            if (shoot != null) // Toggle shooting script
            {
                shoot.enabled = true;
            }
        }
        
        isInTrashCan = false;  // Reset the isInTrashCan variable to false
    }
}