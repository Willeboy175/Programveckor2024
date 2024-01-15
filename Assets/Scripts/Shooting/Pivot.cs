using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPlayer : MonoBehaviour
{
    public Transform player; // Definierar spelarns position
    public float rotationSpeed = 5f; //Bestämmer hur snabbt den ska rotera runt spelaren

    void Update()
    {
        if (player != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Vector3.Distance(player.position, Camera.main.transform.position);

            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector3 direction = (targetPosition - player.position).normalized;

            Quaternion toRotation = Quaternion.LookRotation(direction);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            float distanceFromPlayer = 1f;
            transform.position = player.position + direction * distanceFromPlayer;
        }
        else
        // Det här händer bara ifall att Transformen för spelaren inte finns
        {
            Debug.LogError("Player reference not set. Please assign the player transform.");
        }
    }
}
