using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeJumpTrigger006 : MonoBehaviour
{
    public GameObject jumpTrigger1;
    public GameObject jumpTrigger2;

    public AudioSource jumpMusic;
    public AudioSource jumpMusic2;

    public GameObject zombie1;
    public GameObject zombie2;

    // When trigger is entered:
    void OnTriggerEnter()
    {
        // Disable trigger 1/2's collider along with whichever collider is entered
        jumpTrigger1.gameObject.GetComponent<BoxCollider>().enabled = false;
        jumpTrigger2.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        // If the player entered either trigger one or two, and the first zombie hasn't been killed, play the jumpscare music
        // This means that if the player kills zombie1 without crossing trigger, it won't still play the music if you cross it after zombie1 is dead
        if (gameObject.CompareTag("Trigger1") || gameObject.CompareTag("Trigger2") && zombie1.activeInHierarchy)
        {
            jumpMusic.Play();
        }

        // If the player enters trigger3 and the second zombie isn't dead, play music and start coroutine to stop music
        // Ensures music won't play when player enters trigger3 if player killed zombie2 before entering
        if (gameObject.CompareTag("Trigger3") && zombie2.activeInHierarchy)
        {
            jumpMusic2.Play();
            StartCoroutine(StopJumpMusic2());
        }
    }

    // After 2.5 seconds, stop jumpMusic
    // This must be done because music is not stopped on zombie002 death due to it being stopped by the ZombieDeath script
    IEnumerator StopJumpMusic2()
    {
        yield return new WaitForSeconds(2.5f);
        jumpMusic2.Stop();
    }
}
