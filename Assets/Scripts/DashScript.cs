using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float dashForce = 5000f;
    public bool isDashing;
    float dashCooldown = 2.5f;
    float dashTimer;
    [SerializeField]
    public MovementScript movementScript;
    void Start()
    {
        isDashing = false;
        dashTimer = 0f;
    }
    void Dash()
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
        Invoke("EnableMovement", 0.2f);
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
        if (dashTimer >= dashCooldown)
        {
            Debug.Log("Undvikelseförmågan är redo");
        }
    }
    void EnableMovement()
    {
        isDashing = false;
        movementScript.canMove = true;
        Debug.Log("Movement enabled");
    }
}