using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; //sätter hälsan av gubben
    private int currentHealth; // Är en check på hur mycket hälsa gubben har kvar

    void Start()
    {
        currentHealth = maxHealth; // när man startar så syncar currenthealth med max health
    }

    public void TakeDamage(int damage) // är en check på när gubben tar skada
    {
        currentHealth -= damage;

        if (currentHealth <= 0)// säger att gubbe ska dö om hälsan blir 0
        {
            Die();
        }
    }

    // När gubben dör tas objectet bort
    void Die()
    {
        gameObject.SetActive(false);
    }
}
