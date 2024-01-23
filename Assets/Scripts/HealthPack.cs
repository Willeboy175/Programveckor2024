using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour 
{
    void Start()
    {
        
    }
    public void healthPack(int health, Collision2D Collision)
    {
        HealthPack collision = null;
        if (currentHealth < maxHealth && collision.gameObject.tag == "HealthPack")
        {
            currentHealth += 1;
            print("aktiverad");
        }
    }
    void Update()
    {
        
    }
}
