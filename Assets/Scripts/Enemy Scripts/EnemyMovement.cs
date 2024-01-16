using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Enemy walking speed")]
    public float speed = 2f;
    [Tooltip("For how long enemy should stand still before changing direction")]
    public float stopTime = 2f;
    public LayerMask playerLayer;
    [Space]

    [Header("At what x coordinates the enemy will stay within")]
    [Tooltip("Maximum x position enemy will go to")]
    public int xMax;
    [Tooltip("Minimum x position enemy will go to")]
    public int xMin;
    [Space]

    [Header("Player detection")]
    public float visionDistance = 6f;
    public GameObject visionConeRight;
    public GameObject visionConeLeft;
    [Space]

    [Header("Shooting")]
    public float fireSpeed = 1f;
    public GameObject enemyBullet;
    [Space]

    public SpriteRenderer spriteRenderer;

    public static int direction;

    private Rigidbody2D rb;
    private float xPos; //x coordinates of the enemy
    private float stopTimer;
    private float shootTimer;
    private int faceDirection; //1 is equal to facing right and -1 is equal to facing left
    private Vector2 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
        visionConeRight.SetActive(true);
        visionConeLeft.SetActive(false);
        faceDirection = 1;
    }

    // Update is called once per frame
    void Update()
    {
        xPos = rb.position.x;
        stopTimer += Time.deltaTime;
        shootTimer += Time.deltaTime;
        direction = faceDirection;

        //Raycast to detect player
        RaycastHit2D hit = Physics2D.Raycast(rb.position, new Vector2(faceDirection, 0), visionDistance, playerLayer);

        if (hit) //Checks if raycast have hit a gameobject on "Player" layer
        {
            print("Hit player");
            Transform playerObject = hit.transform;
            playerPos = playerObject.position;
            FollowPlayer();
            Shoot();
        }
        else
        {
            PatrolMovement();
        }
        
        Debug.DrawRay(rb.position, new Vector2(faceDirection * visionDistance, 0));
        
    }

    void PatrolMovement()
    {
        if (stopTimer >= stopTime)
        {
            if (xPos <= xMax && faceDirection == 1) //Decides if enemy should walk right
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else if (xMax <= xPos && faceDirection == 1) //Changes direction enemy should walk
            {
                faceDirection = -1;
                spriteRenderer.flipX = false;
                visionConeRight.SetActive(false);
                visionConeLeft.SetActive(true);
                stopTimer = 0;
            }
            else if (xMin <= xPos && faceDirection == -1) //Decides if enemy should walk left
            {
                rb.velocity = new Vector2(speed * -1, rb.velocity.y);
            }
            else if (xPos <= xMin && faceDirection == -1) //Changes direction enemy should walk
            {
                faceDirection = 1;
                spriteRenderer.flipX = true;
                visionConeRight.SetActive(true);
                visionConeLeft.SetActive(false);
                stopTimer = 0;
            }
        }
    }

    void FollowPlayer()
    {
        if (faceDirection == 1) //If enemy is facing right when seeing player
        {
            //Decides if enemy should walk closer och further away from player
            if (xPos + 4 <= playerPos.x)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else if (xPos + 2 >= playerPos.x)
            {
                rb.velocity = new Vector2(speed * -1, rb.velocity.y);
            }

        }
        else if (faceDirection == -1) //If enemy is facing left when seeing player
        {
            //Decides if enemy should walk closer och further away from player
            if (xPos - 4 >= playerPos.x)
            {
                rb.velocity = new Vector2(speed * -1, rb.velocity.y);
            }
            else if (xPos - 2 <= playerPos.x)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }
    }

    void Shoot()
    {
        if (shootTimer >= fireSpeed)
        {
            if (faceDirection == 1)
            {
                GameObject bullet = Instantiate(enemyBullet, rb.position, Quaternion.Euler(0, 0, 0));
            }
            else if (faceDirection == -1)
            {
                GameObject bullet = Instantiate(enemyBullet, rb.position, Quaternion.Euler(0, 0, 180));
            }
            
            shootTimer = 0;
        }
    }
}
