using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSound : MonoBehaviour
{
    public AudioSource Shooting;
    private bool shootingKeyPressedPrevFrame;

    void Update()
    {
        bool shootingKeyPressed = Input.GetButtonDown("Fire1");

        if (shootingKeyPressed)
        {
            Shooting.volume = Random.Range(0.45f, 0.6f);
            Shooting.pitch = Random.Range(0.95f, 1.05f);
            Shooting.Play();
        }
        else if (!shootingKeyPressedPrevFrame && Shooting.isPlaying)
        {
            Shooting.Stop();
        }

        shootingKeyPressedPrevFrame = shootingKeyPressed;
    }
}
