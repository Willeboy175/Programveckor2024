using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovementScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float movementSpeed = 4f; //hastigheten f�r att g� fram�t och bak�t
    [SerializeField]
    float jumpPower = 5f; //best�mmer hur h�gt man kan hoppa
    [SerializeField]
    float airMovementSpeed = 2f; //justerar hastigheten i luften
    bool isGrounded; //kollar om man �r p� marken
    [SerializeField]
    LayerMask mask;
    private bool _canMove;
    public bool canMove
    {
        get { return _canMove; }
        set { _canMove = value; }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
    }
    void Update()
    {
        if (canMove)
        {
            float horz = Input.GetAxis("Horizontal");
            isGrounded = Physics2D.Raycast(transform.position, -transform.up, 0.6f, mask); //Raycast som skickar ut en str�le f�r att kolla om spelaren befinner sig p� marken eller inte
            Debug.DrawRay(transform.position, -transform.up * 0.5f);
            if (isGrounded == true) //om man �r p� marken
            {
                rb.velocity = new Vector2(movementSpeed * horz, rb.velocity.y); //s� r�r man sig s� h�r snabbt
                if (Input.GetKeyDown(KeyCode.Space)) //och hoppar
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpPower); //s� h�r h�gt
                }
            }
            else //annars
            {
                rb.velocity = new Vector2(airMovementSpeed * horz, rb.velocity.y); //f�rdas man s� h�r snabbt i luften
            }
        }
    }
}