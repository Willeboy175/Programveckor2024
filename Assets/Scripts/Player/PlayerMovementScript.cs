using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Movement")]
    public float currentSpeed;
    public float movementSpeed = 5f; //hastigheten för att gå framåt och bakåt
    public float groundAcceleration = 12f; //Hur snabbt spelaren kan ändra riktning på marken
    public float jumpForce = 7.5f; //bestämmer hur högt man kan hoppa
    [Space]

    [Header("Air movement")]
    public float airSpeedMultiplier = 0.8f; //justerar hastigheten i luften
    public float airAcceleration = 0.015f; //Hur snabbt spelaren kan ändra riktning i luften
    [Space]

    [Header("Ground Checks")]
    public LayerMask groundMask;
    [Space]

    [Header("Other")]
    public float interactionRadius = 2f;
    public LayerMask trashcanLayer;
    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private Vector2 movement;
    private float playerInput;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
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
        playerInput = Input.GetAxisRaw("Horizontal");

        currentSpeed = rb.velocity.x;

        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0, jumpForce));
            }

            Movement(movementSpeed, groundAcceleration, 1);
        }
        else
        {
            Movement(movementSpeed, airAcceleration, airSpeedMultiplier);
        }

        grounded = false;
    }

    void Movement(float speed, float acceleration, float multiplier)
    {
        //Get players input
        Vector2 targetVelocity = new Vector2(playerInput, 0);

        //Calculate target velocity
        targetVelocity *= speed;

        //Players current velocity
        Vector2 velocity = rb.velocity;

        //Calculate change in velocity to hit targetvelocity
        Vector2 velocityChange = targetVelocity - velocity;

        //Sets acceleration to velocityChange
        velocityChange.x = Mathf.Clamp(velocityChange.x, -acceleration, acceleration);
        velocityChange.y += rb.velocity.y;

        //Adds velocityChange to rigidbody
        rb.velocity += new Vector2(velocityChange.x * multiplier, velocityChange.y);
    }
}
