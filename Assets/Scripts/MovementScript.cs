using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovementScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float movementSpeed = 5f;
    [SerializeField]
    float jumpPower = 5f;
    bool isGrounded;
    [SerializeField]
    LayerMask mask;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float horz = Input.GetAxis("Horizontal");

        isGrounded = Physics2D.Raycast(transform.position, -transform.up, 0.6f, mask); //Raycast som skickar ut en stråle för att kolla om spelaren befinner sig på marken eller inte
        Debug.DrawRay(transform.position, -transform.up * 0.5f);
        if (isGrounded == true)
        {
            rb.velocity = new Vector2(movementSpeed * horz, rb.velocity.y);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
            
        }
        else
        {

        }
    }
}
/*void Jump()
{
    rb.velocity = new Vector2(rb.velocity.x, jumpPower);
}*/