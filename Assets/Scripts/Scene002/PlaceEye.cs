using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceEye : MonoBehaviour
{
    public float distance;
    public GameObject actionText;
    public GameObject outerCross;

    public GameObject needEyeText;
    public GameObject wholeEye;

    public GameObject doorWall;
    public AudioSource doorScrape;
    public AudioSource chaseMusic;
    public AudioSource gongSound;

    // Update is called once per frame
    void Update()
    {
        // distance variable is taken and tracked from PlayerCasting script
        distance = PlayerCasting.distanceFromTarget;
    }

    // When mouse is hovering over eye frame's collider
    void OnMouseOver()
    {
        // If player is <= 3 distance from left eye and needEyeText isn't displaying, enable actionText and outer crosshair
        if (distance <= 3 && needEyeText.activeInHierarchy == false)
        {
            actionText.SetActive(true);
            outerCross.SetActive(true);

        }

        // If player presses action button and don't have the whole eye: 
        if (Input.GetButtonDown("Action") && GlobalInventory.hasWholeEye == false)
        {
            // Turn off action text and outerCross, and display text saying we need the rest of the eye, then disable after 2 sec
            actionText.SetActive(false);
            outerCross.SetActive(false);
            needEyeText.SetActive(true);
            StartCoroutine(DeactivateNeedText());
        }

        // If we press action button and do have the whole eye
        if (Input.GetButtonDown("Action") && GlobalInventory.hasWholeEye == true)
        {
            // Turn off action text and outerCross, set fullEye active on wall, and start coroutine to open secret wall door
            actionText.SetActive(false);
            outerCross.SetActive(false);
            wholeEye.SetActive(true);
            gongSound.Play();
            StartCoroutine(OpenWallDoor());
        }
    }

    // After 2 seconds, turn off needEyeText
    IEnumerator DeactivateNeedText()
    {
        yield return new WaitForSeconds(2);
        needEyeText.SetActive(false);
    }

    // After 3 seconds, play the door opening anim and soundfx
    IEnumerator OpenWallDoor()
    {
        yield return new WaitForSeconds(3f);
        doorWall.GetComponent<Animation>().Play("SecretDoorOpen");
        doorScrape.Play();
    }

    // When no longer looking at Eye Display, disable text and outerCross
    void OnMouseExit()
    {
        actionText.SetActive(false);
        outerCross.SetActive(false);
    }
}
