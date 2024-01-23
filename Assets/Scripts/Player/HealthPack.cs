using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int healthAmount = 1; // The amount of health the pack restores

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Get the Player script attached to the player GameObject
            Health player = other.GetComponent<Health>();

            // If the Player script is found, increase player's health
            if (player != null)
            {
                player.Heal(healthAmount);

                // Destroy the health pack object after it's used
                Destroy(gameObject);
            }
        }
    }
}
