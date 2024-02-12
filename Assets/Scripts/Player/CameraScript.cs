using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    Vector3 offset = new Vector3(0, 0, -1); // Avst�ndet mellan kameran och m�let som den ska f�lja
    float smoothTime = 0.25f; // Tiden det tar f�r kameran att smidigt f�lja m�let
    Vector3 velocity = Vector3.zero; // Hastighet som anv�nds f�r smidig f�ljning
    [SerializeField]
    private Transform target; // Transform-komponenten f�r m�let som kameran ska f�lja

    // Metod som k�rs vid varje bilduppdatering
    void Update()
    {
        // Ber�kna m�lets position med h�nsyn till offset
        Vector3 targetPosition = target.position + offset;

        // Anv�nd Vector3.SmoothDamp f�r att smidigt f�lja m�let med kameran
        // Transformera kamerans position till den smidiga f�ljningspositionen
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}