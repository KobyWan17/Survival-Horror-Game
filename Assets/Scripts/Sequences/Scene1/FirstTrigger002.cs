using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstTrigger002 : MonoBehaviour
{
    public GameObject textBox;
    public GameObject gunMarker;
    public GameObject ammoMarker;
    public GameObject firstTrigger;

    public AudioSource line03;

    // When player crosses threshold, start coroutine
    void OnTriggerEnter()
    {
        StartCoroutine(ScenePlayer());
    }

    // Start dialogue/indicators for trigger
    IEnumerator ScenePlayer()
    {
        // Play audio indicating there's a gun on the table, and update subtitles accordingly
        line03.Play();
        yield return new WaitForSeconds(0.5f);
        gunMarker.SetActive(true);
        textBox.GetComponent<Text>().text = "There's something on that table...";
        yield return new WaitForSeconds(2.25f);
        textBox.GetComponent<Text>().text = "Better grab it, might be useful";
        yield return new WaitForSeconds(1.35f);

        // If player hasn't picked up ammo yet, turn on ammo marker arrow
        if (AmmoPickup.hasAmmo == false)
        {
            ammoMarker.SetActive(true);
        }

        // After 0.75 seconds, make text box empty
        yield return new WaitForSeconds(0.75f);
        textBox.GetComponent<Text>().text = "";

        // Disable trigger's collider
        firstTrigger.GetComponent<BoxCollider>().enabled = false;
        
    }
}
