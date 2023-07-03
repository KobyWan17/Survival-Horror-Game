using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupCollisionSound : MonoBehaviour
{
    public AudioSource impactSound;

    // When cup collides with object at a high enough speed, play bonk sound effect
    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1.0f)
        {
            impactSound.Play();
        }
    }
}
