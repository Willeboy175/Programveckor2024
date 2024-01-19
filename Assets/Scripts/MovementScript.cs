using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovementScript : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 5f; //hastigheten för att gå framåt och bakåt
    public float jumpPower = 7.5f; //bestämmer hur högt man kan hoppa
    public float groundMaxVelocityChange = 0.05f; //Hur snabbt spelaren kan ändra riktning på marken
    [Space]

    [Header("Air movement")]
    public float airMaxVelocityChange = 0.015f; //Hur snabbt spelaren kan ändra riktning i luften
    public float airMovementMultiplier = 0.8f; //justerar hastigheten i luften
    [Space]

    [Header("Ground Checks")]
    public LayerMask groundMask;
    public float raycastLength = 1.1f;
    [Space]

    [Header("Other")]
    public float interactionRadius = 2f;
    public LayerMask trashcanLayer;
    public Collider2D playerCollider2D;
    public DashScript DashScript;
    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private float playerInput;
    private bool isGrounded1; //kollar om man är på marken
    private bool isGrounded2;
    private bool _canMove; //Kollar om spelaren får röra på sig

    public bool canMove
    {  
        get { return _canMove; }
        set { _canMove = value; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        if (spriteRenderer == null)
        {
            Debug.LogError("Spriterenderer was not found");
        }
    }

    void Update()
    {
        playerInput = Input.GetAxis("Horizontal");
        
        //Flip the sprite based on player input
        if (playerInput < 0) // Moving left (A key)
        {
            spriteRenderer.flipX = true; //Flip the sprite
        }
        else if (playerInput > 0) //Moving right (D key)
        {
            spriteRenderer.flipX = false; //Unflip the sprite
        }
    }

    void FixedUpdate()
    {
        if (canMove) //Om spelaren kan röra sig
        {
            GroundCheck();
            if (isGrounded1 == true || isGrounded2 == true) //om man är på marken
            {
                if (Input.GetKeyDown(KeyCode.Space)) //Om spelaren hoppar
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpPower); //så här högt
                }

                rb.velocity = rb.velocity + CalculateMovement(movementSpeed, groundMaxVelocityChange);
            }
            else //om spelaren är i luften
            {
                rb.velocity = rb.velocity + CalculateMovement(movementSpeed * airMovementMultiplier, airMaxVelocityChange);
            }
        }
    }
    void GroundCheck()
    {
        isGrounded1 = Physics2D.Raycast(transform.position + new Vector3(0.45f, 0, 0), -transform.up, raycastLength, groundMask); //Raycast som skickar ut en stråle för att kolla om spelaren befinner sig på marken eller inte
        isGrounded2 = Physics2D.Raycast(transform.position + new Vector3(-0.45f, 0, 0), -transform.up, raycastLength, groundMask);

        Debug.DrawRay(transform.position + new Vector3(0.45f, 0, 0), -transform.up * raycastLength);
        Debug.DrawRay(transform.position + new Vector3(-0.45f, 0, 0), -transform.up * raycastLength);
    }

    Vector2 CalculateMovement(float speed, float maxVelocityChange)
    {
        //Get players input
        Vector2 targetVelocity = new Vector2(playerInput, 0);
        targetVelocity = transform.TransformDirection(targetVelocity);

        //Calculate target velocity
        targetVelocity *= speed;

        //Players current velocity
        Vector2 velocity = rb.velocity;

        Vector2 velocityChange = targetVelocity - velocity;

        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.y += rb.velocity.y;

        return velocityChange;
    }
}