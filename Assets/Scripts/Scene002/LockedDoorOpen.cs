using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedDoorOpen : MonoBehaviour
{
    public float distance;
    public GameObject actionText;
    public GameObject outerCross;
    public GameObject lockedDoor;

    public AudioSource doorAudio;

    public AudioSource lockedAudio;
    public GameObject textBox;
    public GameObject keyArrow;

    // Update is called once per frame
    void Update()
    {
        // distance variable is taken and tracked from PlayerCasting script
        distance = PlayerCasting.distanceFromTarget;
    }

    // When mouse is hovering over Collider
    void OnMouseOver()
    {
        // If player is <= 2 distance from door, enable actionText and outer crosshair
        if (distance <= 2)
        {
            actionText.SetActive(true);
            outerCross.SetActive(true);

        }

        // If player presses action button and player has picked up key: 
        if (Input.GetButtonDown("Action") && PickUpKey.hasKey == true)
        {
            if (distance <= 2)
            {
                // Disable door's collider, actionText, and outer crosshair, and play door opening animation/audio
                this.GetComponent<BoxCollider>().enabled = false;
                actionText.SetActive(false);
                outerCross.SetActive(false);
                lockedDoor.GetComponent<Animation>().Play("LockedDoorOpenAnim");
                doorAudio.Play();
            }
        }

        // If player presses action button and hasn't picked up the key, start locked door coroutine
        else if (Input.GetButtonDown("Action") && PickUpKey.hasKey == false)
        {
            StartCoroutine(DoorLockedText());
        }
    }

    // Plays text/dialogue of door being locked
    IEnumerator DoorLockedText()
    {
        // Play audio and text saying door is locked
        lockedAudio.Play();
        yield return new WaitForSeconds(0.6f);
        textBox.GetComponent<Text>().text = "Ugh, it's locked..."; 
        yield return new WaitForSeconds(4.9f);
        textBox.GetComponent<Text>().text = "Must be a key somewhere";
        yield return new WaitForSeconds(1.8f);
        textBox.GetComponent<Text>().text = "";

        // After 10 seconds, turn on key indicator arrow
        yield return new WaitForSeconds(10f);
        keyArrow.SetActive(true);
    }

    // When no longer looking at door, turn off text and outerCross
    void OnMouseExit()
    {
        actionText.SetActive(false);
        outerCross.SetActive(false);
    }
}
