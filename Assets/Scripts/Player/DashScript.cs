using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb; // En referens till Rigidbody-komponenten som anv�nds f�r att applicera kraft p� objektet

    [SerializeField]
    float dashForce = 5; // Styrkan som anv�nds f�r dash

    public bool isDashing; // En variabel f�r att h�lla reda p� om spelaren dashar f�r n�rvarande

    public float dashCooldown = 1.5f; // Tiden det tar innan spelaren kan dasha igen efter en dash

    float dashTimer; // En timer f�r att sp�ra tiden sedan senaste dash

    public MovementScript movementScript; // En referens till MovementScript f�r att hantera spelarens r�relse

    void Start()
    {
        isDashing = false; // N�r spelet startar �r spelaren inte i dash-l�ge
        dashTimer = 0f; // Dash-timern b�rjar fr�n noll
    }

    void Dash() // Funktionen f�r att utf�ra dash
    {
        Vector2 dashDirection = new Vector2(); // Skapar en vektor f�r dash-riktningen

        // Om spelaren trycker p� A-tangenten s�tts dash-riktningen till v�nster
        if (Input.GetKey(KeyCode.A))
        {
            dashDirection = Vector2.left;
        }
        // Om spelaren trycker p� D-tangenten s�tts dash-riktningen till h�ger
        else if (Input.GetKey(KeyCode.D))
        {
            dashDirection = Vector2.right;
        }

        // L�gger till en impuls i dash-riktningen till spelarens Rigidbody
        rb.AddForce(dashDirection * dashForce, ForceMode2D.Impulse);

        // Markerar att spelaren dashar
        isDashing = true;

        // �terst�ller dash-timern
        dashTimer = 0;

        // Markerar att spelaren inte kan r�ra sig under en kort tid efter dash
        movementScript.canMove = false;

        // Anv�nder en f�rdr�jning f�r att �terst�lla r�relsef�rm�gan efter en kort tid
        Invoke("EnableMovement", 0.2f); // S�tter p� movementscriptet efter 0,2 sekunder
    }

    void Update()
    {
        // Kollar om spelaren trycker p� v�nster skifttangenten och inte redan dashar och att dash-timern �r l�ngre �n dash-cooldown
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && dashCooldown < dashTimer)
        {
            Dash(); // Utf�r en dash om villkoren uppfylls
        }

        // Uppdaterar dash-timern med tiden sedan senaste frame
        dashTimer += Time.deltaTime;

        // Om tiden sedan senaste dash �r l�ngre �n 0.5 sekunder, markera att spelaren inte l�ngre dashar
        if (dashTimer > 0.5f)
        {
            isDashing = false;
        }

        // Om dash-timern har n�tt dash-cooldown s� dyker det upp i log/console atat spelaren kan anv�nda dash igen
        if (dashTimer >= dashCooldown)
        {
            Debug.Log("Dash ability ready"); //Om dashtimern �r st�rre eller lika med cooldownen s� printas det att den �r redo
        }
    }
    // Funktion f�r att aktivera spelarens r�relse igen efter en kort f�rdr�jning
    void EnableMovement()
    {
        isDashing = false; // Markerar att spelaren inte l�ngre dashar
        movementScript.canMove = true; // Aktiverar spelarens r�relse igen
        Debug.Log("Movement enabled"); //Skriver ut i konsolen att r�relsen �r aktiverad igen
    }
}