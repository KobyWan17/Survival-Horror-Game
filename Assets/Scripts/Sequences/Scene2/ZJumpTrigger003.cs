using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZJumpTrigger003 : MonoBehaviour
{
    public AudioSource doorBang;
    public AudioSource jumpMusic;
    public AudioSource ambMusic;

    public GameObject zombie;
    public GameObject door;

    // When player enters collider in front of door:
    void OnTriggerEnter()
    {
        // Turn off the collider, play the doorslam animation and jumpscare sound, and start coroutine for rest of jumpscare
        GetComponent<BoxCollider>().enabled = false;
        jumpMusic.Play();
        StartCoroutine(PlayJumpMusic());
    }

    // After 0.3 seconds, make door slam open, play doorBang sound, and activate zombie
    IEnumerator PlayJumpMusic()
    {
        yield return new WaitForSeconds(0.3f);
        door.GetComponent<Animation>().Play("JumpDoorAnim");
        doorBang.Play();
        zombie.SetActive(true);
    }
}
