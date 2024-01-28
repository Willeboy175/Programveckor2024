using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Movement")]
    public float currentSpeed;
    public float movementSpeed = 5f; //hastigheten för att gå framåt och bakåt
    public float groundAcceleration = 0.5f; //Hur snabbt spelaren kan ändra riktning på marken
    public float jumpForce = 7.5f; //bestämmer hur högt man kan hoppa
    [Space]

    [Header("Dash")]
    public float dashSpeed = 10f;
    public float dashCooldown = 1.5f;
    [Space]

    [Header("Air movement")]
    public float airSpeedMultiplier = 0.8f; //justerar hastigheten i luften
    public float airAcceleration = 0.2f; //Hur snabbt spelaren kan ändra riktning i luften
    [Space]

    [Header("Other")]
    public float interactionRadius = 2f;
    public LayerMask trashcanLayer;
    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    public float playerInput;
    public float dashCooldownTimer;
    public bool grounded;
    public bool jumping;
    public bool dashing;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
    }

    // Update is called once per frame
    void Update()
    {
        playerInput = Input.GetAxisRaw("Horizontal"); //Get player input

        if (Input.GetKey(KeyCode.Space))
        {
            jumping = true;
        }
        else
        {
            jumping = false;
        }

        if (Input.GetKey(KeyCode.LeftShift) && playerInput != 0)
        {
            dashing = true;
        }
        else
        {
            dashing = false;
        }

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

    //If ground trigger box is touching something
    void OnTriggerEnter2D(Collider2D collision)
    {
        grounded = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
    }

    void FixedUpdate()
    {
        dashCooldownTimer += Time.fixedDeltaTime;

        currentSpeed = rb.velocity.x;

        if (dashing && dashCooldownTimer > dashCooldown) //Player dash
        {
            rb.velocity = new Vector2(playerInput * dashSpeed, 0);
            dashCooldownTimer = 0;
        }
        else
        {
            if (grounded) //If player standing on ground
            {
                if (jumping) //Is player jumping
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }

                Movement(movementSpeed, groundAcceleration, 1);
            }
            else
            {
                Movement(movementSpeed, airAcceleration, airSpeedMultiplier);
            }
        }
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

        //Adds velocityChange to rigidbody
        rb.velocity += new Vector2(velocityChange.x * multiplier, 0);
    }
}
