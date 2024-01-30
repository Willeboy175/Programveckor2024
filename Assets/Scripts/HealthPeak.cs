using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPeak : MonoBehaviour
{
    public float interactRadius = 0.2f; // Radius within which the player can interact with the trash can
    public LayerMask playerLayer; // Layer mask to filter players for interaction
    public GameObject HealthPack;
    MovementScript playerMovement;
    Health healthValues;
    public ParticleSystem pS;

    void Update()
    {
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, interactRadius, playerLayer);
        if (colliders != null && Health.currentHealth < Health.maxHealth)
        {
            playerMovement = colliders.GetComponent<MovementScript>();
            Debug.Log("Using Healhtpack");
            Activ8HealthPack(playerMovement, healthValues);
        }
    }
    void Activ8HealthPack(MovementScript playerMovement, Health healthValues)
    {
        Health.currentHealth += 1;
        GetComponent<ParticleSystem>().Play();
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        em.enabled = true;
        Deactiv8HealthPack();
    }
    void Deactiv8HealthPack() 
    {
        Destroy(HealthPack);
    }
}