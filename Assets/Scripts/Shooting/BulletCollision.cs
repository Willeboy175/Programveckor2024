using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] public int damage = 20;//best�mmer hur mycket skada en skotten g�r

    void OnTriggerEnter2D(Collider2D other)
    {
        //kollar om objectet som har kolliderats med har ett health script
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            Debug.Log("Died");
            // Om den har ett health script tar den skada
            enemyHealth.TakeDamage(damage);

            
        }
        // Tar bord kullan n�r den kolliderat
        Destroy(gameObject);
    }
}
