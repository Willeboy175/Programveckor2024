using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float aliveTime = 1f;

    private Rigidbody2D rb;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        rb.velocity = new Vector2(bulletSpeed, 0);

        if (timer > aliveTime)
        {
            Destroy(this.gameObject);
        }
    }
}
