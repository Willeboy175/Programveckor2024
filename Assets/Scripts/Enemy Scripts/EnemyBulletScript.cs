using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float aliveTime = 1f;

    private Rigidbody2D rb;
    private float timer;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = EnemyMovement.direction;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        rb.velocity = new Vector2(direction * bulletSpeed, 0);

        if (timer > aliveTime)
        {
            Destroy(this.gameObject);
        }
    }
}
