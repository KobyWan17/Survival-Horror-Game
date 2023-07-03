using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEye : MonoBehaviour
{
    public float distance;
    public GameObject actionText;
    public GameObject outerCross;

    // Eye pickup variables
    public GameObject rightEye;
    public GameObject leftEye;
    public GameObject pickupText1;
    public GameObject pickupText2;
    public AudioSource pickupSound;

    // Final chase variables
    public GameObject vanishWalls;
    public GameObject newWalls;
    public GameObject textWallLights;
    public GameObject beastText;
    public AudioSource chaseMusic;

    public GameObject doorBlockMain; // Invisible collider that blocks door to main room
    public GameObject doorBlockMaze; // Invisible collider that blocks door to maze

    // Update is called once per frame
    void Update()
    {
        // distance variable is taken and tracked from PlayerCasting script
        distance = PlayerCasting.distanceFromTarget;
    }

    // When mouse is hovering over eye piece collider
    void OnMouseOver()
    {
        // If player is <= 3 distance from eye, enable actionText and outer crosshair
        if (distance <= 3)
        {
            actionText.SetActive(true);
            outerCross.SetActive(true);

        }

        // If player presses action button on right (first) eye: 
        if (Input.GetButtonDown("Action") && gameObject.CompareTag("RightEye"))
        {
            // Set hasRightEye from GlobalInventory to true, and play pickup sound
            GlobalInventory.hasRightEye = true;
            pickupText1.SetActive(true);
            pickupSound.Play();

            // Turn off right eye, action text, outerCross, and maze door block
            rightEye.SetActive(false);
            actionText.SetActive(false);
            outerCross.SetActive(false);
            doorBlockMaze.SetActive(false);
        }

        // If player presses action text on left (final) eye
        if (Input.GetButtonDown("Action") && gameObject.CompareTag("LeftEye"))
        {
            // Set hasLeftEye from GlobalInventory to true, play pickup sound, and deactivate leftEye collider and renderer
            GlobalInventory.hasWholeEye = true;
            pickupSound.Play();
            leftEye.GetComponent<MeshRenderer>().enabled = false;
            leftEye.GetComponent<BoxCollider>().enabled = false;

            // Disable actionText and outerCross, display pickupText2, then vanish walls and activate new text/escape walls/lights
            actionText.SetActive(false);
            outerCross.SetActive(false);
            pickupText2.SetActive(true);
            vanishWalls.SetActive(false);
            newWalls.SetActive(true);
            textWallLights.SetActive(true);

            // Then block door and start coroutine to play beast text and music
            doorBlockMain.SetActive(true);
            StartCoroutine(ChaseStart());
        }
    }

    // Start ending chase sequence
    IEnumerator ChaseStart()
    {
        // After 0.5 seconds, display beast awoken text and then after another 0.5 play chase music
        yield return new WaitForSeconds(0.5f);
        beastText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        chaseMusic.Play();
    }

    // When no longer looking at eyes, disable text and outerCross
    void OnMouseExit()
    {
        actionText.SetActive(false);
        outerCross.SetActive(false);
    }
}
