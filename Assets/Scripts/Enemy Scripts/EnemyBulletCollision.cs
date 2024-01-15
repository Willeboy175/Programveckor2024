using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour
{
    [SerializeField] public int damage = 20;//bestämmer hur mycket skada en skotten gör

    void OnTriggerEnter2D(Collider2D other)
    {
        //kollar om objectet som har kolliderats med har ett health script
        Health enemyHealth = other.GetComponent<Health>();

        if (enemyHealth != null)
        {
            Debug.Log("Died");
            // Om den har ett health script tar den skada
            enemyHealth.TakeDamage(damage);

            
        }
        // Tar bord kullan när den kolliderat
        Destroy(gameObject);
    }
}
