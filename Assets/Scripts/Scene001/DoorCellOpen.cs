using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCellOpen : MonoBehaviour
{
    public float distance;
    public GameObject actionText;
    public GameObject outerCross;
    public GameObject door;

    public AudioSource doorAudio;

    public GameObject doorBlock; // Blocks door from being opened before dialogue ends

    // Update is called once per frame
    void Update()
    {
        // distance variable is taken and tracked from PlayerCasting script
        distance = PlayerCasting.distanceFromTarget;
    }

    // When mouse is hovering over door collider
    void OnMouseOver()
    {
        // If player is <= 2 distance from object and door is no longer blocked (dialogue has stopped), enable actionText and outer crosshair
        if (distance <= 2 && doorBlock.activeInHierarchy == false)
        {
            actionText.SetActive(true);
            outerCross.SetActive(true);
        }

        // If player presses action button and is within 2 units of door: 
        if (Input.GetButtonDown("Action") && distance <= 2)
        {
            // Disable doortrigger's collider, actionText, and outer crosshair, and play door opening animation/audio
            this.GetComponent<BoxCollider>().enabled = false;
            actionText.SetActive(false);
            outerCross.SetActive(false);
            door.GetComponent<Animation>().Play("FirstDoorOpenAnim");
            doorAudio.Play();
        }
    }

    // When no longer looking at door, disable text and outerCross
    void OnMouseExit()
    {
        actionText.SetActive(false);
        outerCross.SetActive(false);
    }
}
