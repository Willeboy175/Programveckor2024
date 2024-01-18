using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float dashForce = 5;
    public bool isDashing;
    public float dashCooldown = 1.5f;
    float dashTimer;
    public MovementScript movementScript;
    void Start()
    {
        isDashing = false;
        dashTimer = 0f;
    }
    void Dash() //Funktion för dashen
    {
        Vector2 dashDirection = new Vector2();
        if (Input.GetKey(KeyCode.A))
        {
            dashDirection = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dashDirection = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            dashDirection = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dashDirection = Vector2.down;
        }
        rb.AddForce(dashDirection * dashForce, ForceMode2D.Impulse);
        Debug.Log("Dash Direction: " + dashDirection);
        isDashing = true;
        dashTimer = 0;
        Debug.Log("Undviker");
        movementScript.canMove = false;
        Invoke("EnableMovement", 0.2f); //Sätter på movementscriptet efter 0,2 sekunder
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && dashCooldown < dashTimer)
        {
            Dash();
        }
        dashTimer += Time.deltaTime;
        if (dashTimer > 0.5f)
        {
            isDashing = false;
        }
        if (dashTimer >= dashCooldown) //Om dashtimern är större eller lika med cooldownen så printas det att den är redo
        {
            Debug.Log("Undvikelseförmågan är redo");
        }
    }
    void EnableMovement() //Funktion för att slå på movement igen
    {
        isDashing = false;
        movementScript.canMove = true;
        Debug.Log("Movement enabled");
    }
}