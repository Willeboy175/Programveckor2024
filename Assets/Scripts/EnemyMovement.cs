using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("At what x coordinates the enemy will stay within")]
    [Tooltip("Maximum x position enemy will go to")]
    public int xMax;
    [Tooltip("Minimum x position enemy will go to")]
    public int xMin;
    [Space]

    [Tooltip("Enemy walking speed")]
    public float speed = 3f;
    [Tooltip("For how long enemy should stand still before changing direction")]
    public float stopTime = 3f;

    private Rigidbody2D rb;
    private float xPos;
    private float timer;
    private bool walkingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xPos = rb.position.x;
        timer += Time.deltaTime;
        PatrolMovement();
    }

    public virtual void PatrolMovement()
    {
        if (timer >= stopTime)
        {
            if (xPos <= xMax && walkingRight) //Decides if enemy should walk right
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else if (xMax <= xPos && walkingRight) //Changes direction enemy should walk
            {
                walkingRight = false;
                timer = 0;
            }
            else if (xMin <= xPos && walkingRight == false) //Decides if enemy should walk left
            {
                rb.velocity = new Vector2(speed * -1, rb.velocity.y);
            }
            else if (xPos <= xMin && walkingRight == false) //Changes direction enemy should walk
            {
                walkingRight = true;
                timer = 0;
            }
        }
    }
}
