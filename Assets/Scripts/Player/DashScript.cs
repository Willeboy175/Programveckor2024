using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb; // En referens till Rigidbody-komponenten som används för att applicera kraft på objektet

    [SerializeField]
    float dashForce = 5; // Styrkan som används för dash

    public bool isDashing; // En variabel för att hålla reda på om spelaren dashar för närvarande

    public float dashCooldown = 1.5f; // Tiden det tar innan spelaren kan dasha igen efter en dash

    float dashTimer; // En timer för att spåra tiden sedan senaste dash

    public MovementScript movementScript; // En referens till MovementScript för att hantera spelarens rörelse

    void Start()
    {
        isDashing = false; // När spelet startar är spelaren inte i dash-läge
        dashTimer = 0f; // Dash-timern börjar från noll
    }

    void Dash() // Funktionen för att utföra dash
    {
        Vector2 dashDirection = new Vector2(); // Skapar en vektor för dash-riktningen

        // Om spelaren trycker på A-tangenten sätts dash-riktningen till vänster
        if (Input.GetKey(KeyCode.A))
        {
            dashDirection = Vector2.left;
        }
        // Om spelaren trycker på D-tangenten sätts dash-riktningen till höger
        else if (Input.GetKey(KeyCode.D))
        {
            dashDirection = Vector2.right;
        }

        // Lägger till en impuls i dash-riktningen till spelarens Rigidbody
        rb.AddForce(dashDirection * dashForce, ForceMode2D.Impulse);

        // Markerar att spelaren dashar
        isDashing = true;

        // Återställer dash-timern
        dashTimer = 0;

        // Markerar att spelaren inte kan röra sig under en kort tid efter dash
        movementScript.canMove = false;

        // Använder en fördröjning för att återställa rörelseförmågan efter en kort tid
        Invoke("EnableMovement", 0.2f); // Sätter på movementscriptet efter 0,2 sekunder
    }

    void Update()
    {
        // Kollar om spelaren trycker på vänster skifttangenten och inte redan dashar och att dash-timern är längre än dash-cooldown
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && dashCooldown < dashTimer)
        {
            Dash(); // Utför en dash om villkoren uppfylls
        }

        // Uppdaterar dash-timern med tiden sedan senaste frame
        dashTimer += Time.deltaTime;

        // Om tiden sedan senaste dash är längre än 0.5 sekunder, markera att spelaren inte längre dashar
        if (dashTimer > 0.5f)
        {
            isDashing = false;
        }

        // Om dash-timern har nått dash-cooldown så dyker det upp i log/console atat spelaren kan använda dash igen
        if (dashTimer >= dashCooldown)
        {
            Debug.Log("Dash ability ready"); //Om dashtimern är större eller lika med cooldownen så printas det att den är redo
        }
    }
    // Funktion för att aktivera spelarens rörelse igen efter en kort fördröjning
    void EnableMovement()
    {
        isDashing = false; // Markerar att spelaren inte längre dashar
        movementScript.canMove = true; // Aktiverar spelarens rörelse igen
        Debug.Log("Movement enabled"); //Skriver ut i konsolen att rörelsen är aktiverad igen
    }
}