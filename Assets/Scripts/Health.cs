using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject HealthBar, HealthBar2, HealthBar3; //Ska visa spelaren hur mycket hälsa man har kvar
    public int maxHealth = 3; //sätter hälsan av gubben
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
    void Update()
    {
        if (currentHealth == 2)
        {
            HealthBar3.SetActive(false);
        }
        if (currentHealth == 1)
        {
            HealthBar2.SetActive(false);
        }
        if (currentHealth <= 0)
        {
            HealthBar.SetActive(false);
        }
        else if (currentHealth == maxHealth)
        {
            HealthBar.SetActive(true);
            HealthBar2.SetActive(true);
            HealthBar3.SetActive(true);
        }
    }
    // När gubben dör tas objectet bort
    void Die()
    {
        gameObject.SetActive(false);
    }
}
