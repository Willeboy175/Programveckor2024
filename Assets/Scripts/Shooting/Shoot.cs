using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform gunBarrelTransform;
    public GameObject bulletPrefab;
    [SerializeField] public float bulletForce = 10f;
    [SerializeField] public float fireRate = 0.5f;

    private float nextFireTime;

    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shooting();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shooting()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 shootDirection = (mousePosition - (Vector2)gunBarrelTransform.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, gunBarrelTransform.position, gunBarrelTransform.rotation);


        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();


        if (bulletRb != null)
        {
            bulletRb.AddForce(shootDirection * bulletForce, ForceMode2D.Impulse);
        }

        bulletRb.gravityScale = 0f;

        Destroy(bullet, 3f);
    }
}
