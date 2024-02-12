using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int healAmount = 1; // M�ngd h�lsa som h�lsopaketet kommer att l�gga till
    public float interactionRadius = 0.5f; // Radie inom vilken spelaren kan interagera med h�lsopaketet
    public LayerMask playerLayer; // Lagmask f�r att filtrera spelare f�r interaktion
    public GameObject pS; // Partikelsystem som spelas n�r h�lsopaketet anv�nds

    public PlayerMovementScript playerMovement; // Referens till spelarens r�relseskript
    public Health healthScript; // Referens till h�lsoskriptet f�r spelaren

    void Start()
    {
        // Startmetoden anv�nds inte f�r n�rvarande, kan anv�ndas f�r initialisering om det beh�vs
    }

    void Update()
    {
        // Kontrollera f�r spelare inom interaktionsradien
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, interactionRadius, playerLayer);

        if (colliders != null)
        {
            // H�mta referenser till spelarens skript
            playerMovement = colliders.GetComponent<PlayerMovementScript>();
            healthScript = colliders.GetComponent<Health>();

            // Kontrollera om spelarens aktuella h�lsa �r mindre �n maximal h�lsa
            if (Health.getCurrentHealth < Health.getMaxHealth)
            {
                Debug.Log("Using Healthpack"); // Skriv ut ett meddelande till konsolen f�r att bekr�fta anv�ndningen av h�lsopaketet
                healthScript.Heal(healAmount); // L�gg till h�lsa till spelaren genom att anropa h�lsa metoden
                Instantiate(pS, transform.position, Quaternion.identity); // Skapa partikelsystemet p� h�lsopaketets position
                Destroy(gameObject); // F�rst�r h�lsopaketet efter att det har anv�nts
            }
        }
    }
}