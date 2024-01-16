using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject HealthBar, HealthBar2, HealthBar3; //Ska visa spelaren hur mycket h�lsa man har kvar
    public int maxHealth = 3; //s�tter h�lsan av gubben
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
    // N�r gubben d�r tas objectet bort
    void Die()
    {
        gameObject.SetActive(false);
    }
}
