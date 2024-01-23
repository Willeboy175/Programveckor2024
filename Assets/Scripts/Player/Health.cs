using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject HealthBar, HealthBar2, HealthBar3; //Ska visa spelaren hur mycket hälsa man har kvar
    public static int maxHealth = 3; //sätter hälsan av gubben
    public static int currentHealth; // Är en check på hur mycket hälsa gubben har kvar
    public GameObject GameOverPanel; //Visar en panel när man dör

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
public void TakeDamage(int damage) // är en check på när gubben tar skada
    {
        currentHealth -= damage;

        if (currentHealth <= 0)// säger att gubbe ska dö om hälsan blir 0
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
        //Om hälsan är under ett visst värde inaktiveras en del av healthbaren 
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
    // När gubben dör tas den bort, healthbaren tas bort och game over screenen visas upp
    void Die()
    {
        GameOverPanel.SetActive(true);//-Malte & Edvin
        HealthBar.SetActive(false);//-Malte
        gameObject.SetActive(false);//-Robin
    }
}
