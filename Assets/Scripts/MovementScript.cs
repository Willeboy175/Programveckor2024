using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovementScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float movementSpeed = 4f; //hastigheten för att gå framåt och bakåt
    [SerializeField]
    float jumpPower = 5f; //bestämmer hur högt man kan hoppa
    [SerializeField]
    float airMovementSpeed = 2f; //justerar hastigheten i luften
    bool isGrounded; //kollar om man är på marken
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
            isGrounded = Physics2D.Raycast(transform.position, -transform.up, 0.6f, mask); //Raycast som skickar ut en stråle för att kolla om spelaren befinner sig på marken eller inte
            Debug.DrawRay(transform.position, -transform.up * 0.5f);
            if (isGrounded == true) //om man är på marken
            {
                rb.velocity = new Vector2(movementSpeed * horz, rb.velocity.y); //så rör man sig så här snabbt
                if (Input.GetKeyDown(KeyCode.Space)) //och hoppar
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpPower); //så här högt
                }
            }
            else //annars
            {
                rb.velocity = new Vector2(airMovementSpeed * horz, rb.velocity.y); //färdas man så här snabbt i luften
            }
        }
    }
}