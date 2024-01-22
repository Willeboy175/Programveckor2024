using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform gunBarrelTransform; // Där skotten kommer ifrån
    public GameObject bulletPrefab; // Den prefaben som man skjuter
    [SerializeField] public float bulletForce = 10f; // hur snabbt skotten åker
    [SerializeField] public float fireRate = 1f; // Hur snabbt man skjuter
    public AudioSource ShootingSound;
    private float nextFireTime;

    public SpriteRenderer gunSprite;


    void Update()
    {
        // Frågar om man har klickat knappen associerad med fire1 och kollar hur lång tid till nästa skott
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            ShootingSound.volume = Random.Range(0.45f, 0.6f);
            ShootingSound.pitch = Random.Range(0.8f, 0.85f);
            ShootingSound.Play();
            Shooting();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shooting()
    {
        // Definierar muspekarens position och omvandlar det till den positionen som skotten ska åka emot
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // vart den ska skjuta mot
        Vector2 shootDirection = (mousePosition - (Vector2)gunBarrelTransform.position).normalized;

        //Skapar skottet som ska skjutas och bestämmer var skottet ska skapas
        GameObject bullet = Instantiate(bulletPrefab, gunBarrelTransform.position, Quaternion.identity);

        // Kollar om det finns en Rigidbody
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        // Om Rigidbody finns ska den använda sig av shootdirection gånger den satta bullet force för att bestämma hur snabbt den ska ta sig till ditt den ska vara
        if (bulletRb != null)
        {
            bulletRb.AddForce(shootDirection * bulletForce, ForceMode2D.Impulse);
        }

        // Används för att eliminera bullet drop
        bulletRb.gravityScale = 0f;

        // Förstör skotten efter X antal sekunder
        Destroy(bullet, 3f);
    }
}
