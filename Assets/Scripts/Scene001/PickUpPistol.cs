using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpPistol : MonoBehaviour
{
    public float distance;

    // UI elements
    public GameObject outerCross;
    public GameObject actionText;

    // Display pistol on table and real animated pistol
    public GameObject fakePistol;
    public GameObject realPistol;

    public GameObject guideArrow;
    public GameObject jumpTrigger;

    public AudioSource gunPickup;


    // Update is called once per frame
    void Update()
    {
        // distance variable is taken and tracked from PlayerCasting script
        distance = PlayerCasting.distanceFromTarget;
    }

    // When mouse is hovering over gun collider
    void OnMouseOver()
    {
        // If player is <= desired distance from gun, enable actionText and outer crosshair
        if (distance <= 5f)
        {
            actionText.SetActive(true);
            outerCross.SetActive(true);

        }

        // If player presses action button and is within desired distance of object: 
        if (Input.GetButtonDown("Action") && distance <= 5f)
        {
            // Play sound of picking up gun
            gunPickup.Play();

            // Disable guntrigger's collider, actionText, outer crosshair, fake table gun, and guide arrow, and enable real gun in hand
            this.GetComponent<BoxCollider>().enabled = false;
            actionText.SetActive(false);
            outerCross.SetActive(false);
            fakePistol.SetActive(false);
            guideArrow.SetActive(false);
            realPistol.SetActive(true);

            // Once real gun is enabled, set trigger for jumpscare to active
            jumpTrigger.SetActive(true);
        }
    }

    // When no longer looking at gun, disable text and outerCross
    void OnMouseExit()
    {
        actionText.SetActive(false);
        outerCross.SetActive(false);
    }
}
