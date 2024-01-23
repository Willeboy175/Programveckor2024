using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject HealthBar, HealthBar2, HealthBar3; //Ska visa spelaren hur mycket h�lsa man har kvar
    public static int maxHealth = 3; //s�tter h�lsan av gubben
    public static int currentHealth; // �r en check p� hur mycket h�lsa gubben har kvar
    public GameObject GameOverPanel; //Visar en panel n�r man d�r

    public static int getCurrentHealth;
    public static int getMaxHealth;
    private void Start()
    {
        currentHealth = maxHealth;
        getMaxHealth = maxHealth;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        // Ensure the player's health doesn't exceed the maximum health
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        // You can also update a health bar UI here if you have one
        Debug.Log("Player healed! Current Health: " + currentHealth);
    }
public void TakeDamage(int damage) // �r en check p� n�r gubben tar skada
    {
        currentHealth -= damage;

        if (currentHealth <= 0)// s�ger att gubbe ska d� om h�lsan blir 0
        {
            Die();
        }
    }
    
    public void HealthPack(int health, Collision2D Collision)
    {
        HealthPack collision = null;
        if (currentHealth < maxHealth && collision.gameObject.tag == "HealthPack")
        {
            currentHealth += 1;
        }
    }
    void Update()
    {
        //Om h�lsan �r under ett visst v�rde inaktiveras en del av healthbaren 
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
        getCurrentHealth = currentHealth;
    }
    // N�r gubben d�r tas den bort, healthbaren tas bort och game over screenen visas upp
    void Die()
    {
        GameOverPanel.SetActive(true);//-Malte & Edvin
        HealthBar.SetActive(false);//-Malte
        gameObject.SetActive(false);//-Robin
    }
}
