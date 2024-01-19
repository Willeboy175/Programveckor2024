using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; //s�tter h�lsan av gubben
    private int currentHealth; // �r en check p� hur mycket h�lsa gubbenm har kvar

    void Start()
    {
        currentHealth = maxHealth; // n�r man startar s� syncar currenthealth med max health
    }

    public void TakeDamage(int damage) // �r en check p� n�r gubben tar skada
    {
        currentHealth -= damage;

        if (currentHealth <= 0)// Om fiendens h�lsa �r mindre �n �n 0 tas den bort
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
