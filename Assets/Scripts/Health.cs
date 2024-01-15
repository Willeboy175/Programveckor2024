using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; //s�tter h�lsan av gubben
    private int currentHealth; // �r en check p� hur mycket h�lsa gubben har kvar

    void Start()
    {
        currentHealth = maxHealth; // n�r man startar s� syncar currenthealth med max health
    }

    public void TakeDamage(int damage) // �r en check p� n�r gubben tar skada
    {
        currentHealth -= damage;

        if (currentHealth <= 0)// s�ger att gubbe ska d� om h�lsan blir 0
        {
            Die();
        }
    }

    // N�r gubben d�r tas objectet bort
    void Die()
    {
        gameObject.SetActive(false);
    }
}
