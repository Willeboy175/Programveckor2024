using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPeak : MonoBehaviour
{
    public float interactRadius = 0.2f; // Radius within which the player can interact with the trash can
    public LayerMask playerLayer; // Layer mask to filter players for interaction
    public GameObject interactionText; //Text will appear when the player is close to the trashcan

    MovementScript playerMovement;
    Health healthValues;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, interactRadius, playerLayer);
        if (colliders != null && Health.currentHealth < Health.maxHealth)
        {
            interactionText.SetActive(true);
            playerMovement = colliders.GetComponent<MovementScript>();
            Debug.Log("Using Healhtpack");
            Activ8HealthPack(playerMovement, healthValues);
        }
        else
        {
            interactionText.SetActive(false);
        }
    }
    void Activ8HealthPack(MovementScript playerMovement, Health healthValues)
    {
        Health.currentHealth += 1;
    }
}