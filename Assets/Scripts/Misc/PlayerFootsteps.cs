using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    private CharacterController characterController;
    private AudioSource footstepClip;
    private float accumulatedDistance;

    [SerializeField]
    private AudioClip[] footstepSounds;

    [HideInInspector]
    public float minVolume, maxVolume;

    [HideInInspector]
    public float stepDistance;

    private bool disableScript = false;
    private float interval = 0.65f;
    private float trackedTime = 0.0f;


    // Start is called before the first frame update
    void Awake()
    {
        footstepClip = GetComponent<AudioSource>();
        characterController = GetComponentInParent<CharacterController>();

        if (interval < 0.01f)
        { // Make sure the interval isn't 0, or we'll be constantly playing the sound
            Debug.LogError("Interval base must be at least 1.0!");
            disableScript = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckToPlayFootstepSound();
    }


    void CheckToPlayFootstepSound()
    {
        // If character is not grounded, do not run method
        if (!characterController.isGrounded)
            return;

        // If square root of velocity is greater than 0 (means we are moving) and script is running:
        if (characterController.velocity.sqrMagnitude > 0 && !disableScript)
        {
            // Increment the timer
            trackedTime += Time.deltaTime;

            // If the correct amount of time has passed
            if (trackedTime >= interval)
            {
                // If left shift is being pressed
                if (Input.GetKey("left shift"))
                {
                    // Change the interval to be sprint speed, play the sounds louder, and reset timer
                    interval = .25f;
                    footstepClip.PlayOneShot(footstepSounds[Random.Range(0, footstepSounds.Length)], Random.Range(0.3f, 0.4f));
                    trackedTime = 0.0f;
                }
                else
                {
                    // Reset interval to walk speed, play sounds quieter, and reset timer
                    interval = .65f;
                    footstepClip.PlayOneShot(footstepSounds[0], Random.Range(0.1f, 0.2f));
                    trackedTime = 0.0f;
                }
            }
        }
    }
    
}