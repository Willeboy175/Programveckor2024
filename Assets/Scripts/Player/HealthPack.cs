using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int healAmount = 1; // Amount of health healthpack will add
    public float interactionRadius = 0.5f; // Radius within which the player can interact with the healthpack
    public LayerMask playerLayer; // Layer mask to filter players for interaction
    public GameObject pS;

    public PlayerMovementScript playerMovement;
    public Health healthScript;

    void Start()
    {
        
    }

    void Update()
    {
        // Check for players within the interaction radius
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, interactionRadius, playerLayer);

        if (colliders != null)
        {
            playerMovement = colliders.GetComponent<PlayerMovementScript>();
            healthScript = colliders.GetComponent<Health>();

            if (Health.getCurrentHealth < Health.getMaxHealth)
            {
                Debug.Log("Using Healhtpack");
                healthScript.Heal(healAmount);
                Instantiate(pS, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}