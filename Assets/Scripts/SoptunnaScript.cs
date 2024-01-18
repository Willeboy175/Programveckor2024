using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoptunnaScript : MonoBehaviour
{
    public bool isInTrashCan = false; // Variable indicating whether the player is currently in the trash can
    public float interactionRadius = 2f; // Radius within which the player can interact with the trash can
    public LayerMask playerLayer; // Layer mask to filter players for interaction
    public GameObject interactionText;

    MovementScript playerMovement;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
    // Update is called once per frame
    void Update()
    {
        // Check for players within the interaction radius
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, interactionRadius, playerLayer);

        // Check if the interaction key (E) is pressed
        bool interactKeyPressed = Input.GetKeyDown(KeyCode.E);

        if (colliders != null)
        {
            interactionText.SetActive(true);
            playerMovement = colliders.GetComponent<MovementScript>();

            // Check if the playerMovement component is not null
            if (playerMovement != null && interactKeyPressed)
            {
                InteractWithTrashcan(playerMovement);
            }
        } 
        else if (playerMovement != null && interactKeyPressed)
        {
            ExitTrashcan(playerMovement);
            playerMovement = null;
        }
        else
        {
            interactionText.SetActive(false);
        }
    }
    void InteractWithTrashcan(MovementScript playerMovement)
    {
        Debug.Log("Entering the trash can");
        // Get relevant components from the player
        SpriteRenderer playerSpriteRenderer = playerMovement.GetComponent<SpriteRenderer>();
        Collider2D playerCollider2D = playerMovement.GetComponent<Collider2D>();
        Rigidbody2D playerRigidBody2D = playerMovement.GetComponent<Rigidbody2D>();
        DashScript dashScript = playerMovement.GetComponent<DashScript>();
        if (playerRigidBody2D != null)  // Disable gravity for the player when in the trash can
        {
            playerRigidBody2D.gravityScale = 0f;
            playerRigidBody2D.velocity = Vector2.zero;
        }
        if (playerSpriteRenderer != null)   // Toggle the visibility of the player's sprite
        {
            playerSpriteRenderer.enabled = false;
        }
        if (playerCollider2D != null)   // Toggle the player's collider
        {
            playerCollider2D.enabled = false;
        }
        if (dashScript != null)   // Toggle dash script to enable/disable dash ability
        {
            dashScript.enabled = false;
        }
        playerMovement.canMove = false;  // Toggle the player's ability to move
        isInTrashCan = !isInTrashCan;  // Toggle the isInTrashCan variable
    }
    void ExitTrashcan(MovementScript playerMovement)
    {
        Debug.Log("Exiting the trash can");
        // Get relevant components from the player
        SpriteRenderer playerSpriteRenderer = playerMovement.GetComponent<SpriteRenderer>();
        Collider2D playerCollider2D = playerMovement.GetComponent<Collider2D>();
        Rigidbody2D playerRigidBody2D = playerMovement.GetComponent<Rigidbody2D>();
        DashScript dashScript = playerMovement.GetComponent<DashScript>();
        if (playerRigidBody2D != null)  // Enable gravity for the player when exiting the trash can
        {
            playerRigidBody2D.gravityScale = 1f;
            playerRigidBody2D.velocity = Vector2.zero;
        }
        if (playerSpriteRenderer != null)   // Toggle the visibility of the player's sprite
        {
            playerSpriteRenderer.enabled = true;
        }
        if (playerCollider2D != null)   // Toggle the player's collider
        {
            playerCollider2D.enabled = true;
        }
        if (dashScript != null)   // Toggle dash script to enable/disable dash ability
        {
            dashScript.enabled = true;
        }        
        playerMovement.canMove = true; // Toggle the player's ability to move
        isInTrashCan = false;  // Reset the isInTrashCan variable to false
    }
}