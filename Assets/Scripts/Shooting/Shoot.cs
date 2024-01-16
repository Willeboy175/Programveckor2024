using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform gunBarrelTransform; // D�r skotten kommer ifr�n
    public GameObject bulletPrefab; // Den prefaben som man skjuter
    [SerializeField] public float bulletForce = 10f; // hur snabbt skotten �ker
    [SerializeField] public float fireRate = 3f; // HUr snabbt man skuter

    private float nextFireTime;

    void Update()
    {
        // Fr�gar om man har klickat knappen associerad med fire1 och kollar hur l�ng tid till n�sta skott
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime) 
        {
            Shooting();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shooting()
    {
        // Definierar muspekarens position och omvandlar det till den positionen som skotten ska �ka emot
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 shootDirection = (mousePosition - (Vector2)gunBarrelTransform.position).normalized;
        
        //Skapar skottet som ska skjutas och best�mmer var skottet ska skapas
        GameObject bullet = Instantiate(bulletPrefab, gunBarrelTransform.position, Quaternion.identity);

        // Kollar om det finns en Rigidbody
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        // Om Rigidbody finns ska den anv�nda sig av shootdirection g�nger den satta bullet force f�r att best�mma hur snabbt den ska ta sig till ditt den ska vara
        if (bulletRb != null)
        {
            bulletRb.AddForce(shootDirection * bulletForce, ForceMode2D.Impulse);
        }

        // Anv�nds f�r att elimenera bullet drop
        bulletRb.gravityScale = 0f;

        // F�rst�r skotten efter X antal sekunder
        Destroy(bullet, 3f);
    }
}
