using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitDoorOpen : MonoBehaviour
{
    public float distance;
    public GameObject actionText;
    public GameObject outerCross;

    public GameObject fadeOut; // Anim that fades screen to black


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

        // If player presses action button: 
        if (Input.GetButtonDown("Action") && distance <= 2)
        {
            // Disable door's collider, set actionText and outerCross to false, fade screen to black, and start FadeToExit Coroutine
            // Also reset hasAmmo from AmmoPickup so it's back to false for Scene002
            this.GetComponent<BoxCollider>().enabled = false;
            actionText.SetActive(false);
            fadeOut.SetActive(true);
            outerCross.SetActive(false);
            AmmoPickup.hasAmmo = false;
            StartCoroutine(FadeToExit());
        }
    }

    // When no longer looking at door, disable text and outerCross
    void OnMouseExit()
    {
        actionText.SetActive(false);
        outerCross.SetActive(false);
    }

    // After 3 seconds, load Scene002
    IEnumerator FadeToExit()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(5);
    }
}
