using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int healAmount = 1; // Mängd hälsa som hälsopaketet kommer att lägga till
    public float interactionRadius = 0.5f; // Radie inom vilken spelaren kan interagera med hälsopaketet
    public LayerMask playerLayer; // Lagmask för att filtrera spelare för interaktion
    public GameObject pS; // Partikelsystem som spelas när hälsopaketet används

    public PlayerMovementScript playerMovement; // Referens till spelarens rörelseskript
    public Health healthScript; // Referens till hälsoskriptet för spelaren

    void Start()
    {
        // Startmetoden används inte för närvarande, kan användas för initialisering om det behövs
    }

    void Update()
    {
        // Kontrollera för spelare inom interaktionsradien
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, interactionRadius, playerLayer);

        if (colliders != null)
        {
            // Hämta referenser till spelarens skript
            playerMovement = colliders.GetComponent<PlayerMovementScript>();
            healthScript = colliders.GetComponent<Health>();

            // Kontrollera om spelarens aktuella hälsa är mindre än maximal hälsa
            if (Health.getCurrentHealth < Health.getMaxHealth)
            {
                Debug.Log("Using Healthpack"); // Skriv ut ett meddelande till konsolen för att bekräfta användningen av hälsopaketet
                healthScript.Heal(healAmount); // Lägg till hälsa till spelaren genom att anropa hälsa metoden
                Instantiate(pS, transform.position, Quaternion.identity); // Skapa partikelsystemet på hälsopaketets position
                Destroy(gameObject); // Förstör hälsopaketet efter att det har använts
            }
        }
    }
}