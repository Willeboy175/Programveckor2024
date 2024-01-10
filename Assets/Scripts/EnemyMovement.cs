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
    public float speed = 10f;

    private Rigidbody2D rb;
    private float xPos;
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
    }

    public virtual void Movement()
    {
        //Decides if enemy should walk right
        if (xPos <= xMax && walkingRight)
        {
            rb.velocity = new Vector2(Time.deltaTime * speed, rb.velocity.y);
        }

        //still need to add statement to walk left and change directions
    }
}
