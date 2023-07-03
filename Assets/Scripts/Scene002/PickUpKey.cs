using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public float distance;
    public GameObject actionText;
    public GameObject outerCross;

    public GameObject key;
    public AudioSource keyPickup;
    public static bool hasKey;
    public GameObject keyArrow;

    // Update is called once per frame
    void Update()
    {
        distance = PlayerCasting.distanceFromTarget;
    }

    // When mouse is hovering over key collider
    void OnMouseOver()
    {
        // If player is <= 3 distance from key, enable actionText and outer crosshair
        if (distance <= 3)
        {
            actionText.SetActive(true);
            outerCross.SetActive(true);

        }

        // If player presses action button: 
        if (Input.GetButtonDown("Action"))
        {
            // Disable key's collider, actionText, and outer crosshair, set key to inactive and hasKey to true, then disable keyArrow
            this.GetComponent<BoxCollider>().enabled = false;
            keyPickup.Play();
            key.SetActive(false);
            actionText.SetActive(false);
            outerCross.SetActive(false);
            hasKey = true;
            keyArrow.SetActive(false);
        }
    }

    // When no longer looking at key, disable text and outerCross
    void OnMouseExit()
    {
        actionText.SetActive(false);
        outerCross.SetActive(false);
    }
}
