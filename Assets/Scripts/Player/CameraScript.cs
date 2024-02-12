using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    Vector3 offset = new Vector3(0, 0, -1); // Avståndet mellan kameran och målet som den ska följa
    float smoothTime = 0.25f; // Tiden det tar för kameran att smidigt följa målet
    Vector3 velocity = Vector3.zero; // Hastighet som används för smidig följning
    [SerializeField]
    private Transform target; // Transform-komponenten för målet som kameran ska följa

    // Metod som körs vid varje bilduppdatering
    void Update()
    {
        // Beräkna målets position med hänsyn till offset
        Vector3 targetPosition = target.position + offset;

        // Använd Vector3.SmoothDamp för att smidigt följa målet med kameran
        // Transformera kamerans position till den smidiga följningspositionen
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}