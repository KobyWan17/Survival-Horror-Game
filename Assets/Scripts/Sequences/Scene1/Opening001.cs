using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Opening001 : MonoBehaviour
{
    public GameObject player;
    public GameObject fadeScreenIn;
    public GameObject textBox;

    // Dialogue audio
    public AudioSource line01;
    public AudioSource line02;

    public GameObject doorBlock; // Blocks door from being opened before dialogue ends

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScenePlayer());
    }

    // Start dialogue/indicators for trigger
    IEnumerator ScenePlayer()
    {
        // Wait for 2 seconds, then turn off fadeScreenIn, display text on screen, and play 1st dialogue
        yield return new WaitForSeconds(2.0f);
        fadeScreenIn.SetActive(false);
        line01.Play();
        yield return new WaitForSeconds(4.0f);
        textBox.GetComponent<Text>().text = "W-what is this place?";

        // After 2.75 seconds, reset text to blank
        yield return new WaitForSeconds(2.75f);
        textBox.GetComponent<Text>().text = "";

        // Wait for 0.5 seconds, display new text and play 2nd dialogue
        yield return new WaitForSeconds(0.5f);
        line02.Play();
        yield return new WaitForSeconds(0.5f);
        textBox.GetComponent<Text>().text = "Oh god... I need to get out of here";

        // After 3.4 seconds, reset text to blank and allow door to be opened/walked through
        yield return new WaitForSeconds(3.4f);
        textBox.GetComponent<Text>().text = "";
        doorBlock.SetActive(false);
    }
    
}
