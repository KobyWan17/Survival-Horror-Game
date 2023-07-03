using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroDialogue : MonoBehaviour
{
    public GameObject textBox;

    // Dialogue lines
    public AudioSource line01;
    public AudioSource line02;
    public AudioSource line03;
    public AudioSource line04;
    public AudioSource line05;
    public AudioSource line06;

    // Variables for ending knockout transition
    public GameObject blackScreen;
    public GameObject loadingText;
    public AudioSource thudSound;

    // Start coroutine to play dialogue
    void Start()
    {
        StartCoroutine(DialogueSequence());
    }

    IEnumerator DialogueSequence()
    {
        // At specified intervals: Play audio clip, display subtitles, clear subtitles, and start countdown to repeat
        // After 10 seconds, start narration
        yield return new WaitForSeconds(10);

        // Line 1 of narration
        line01.Play();
        yield return new WaitForSeconds(0.5f);
        textBox.GetComponent<Text>().text = "The night of October 9th, 1993 changed me forever";
        yield return new WaitForSeconds(5.5f);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(0.5f);

        // Line 2 of narration
        line02.Play();
        yield return new WaitForSeconds(0.75f);
        textBox.GetComponent<Text>().text = "While on vacation in Japan, the locals had told stories of a haunted forest, one that should be avoided by any sensible person";
        yield return new WaitForSeconds(9.6f);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(0.05f);

        // Line 3 of narration
        line03.Play();
        yield return new WaitForSeconds(0.75f);
        textBox.GetComponent<Text>().text = "But no one had ever described me as 'sensible', so like the fool I was, I decided to check it out. Alone, in the middle of the night, without warning anyone where I was going";
        yield return new WaitForSeconds(13.75f);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(0.5f);

        // Line 4 of narration
        line04.Play();
        yield return new WaitForSeconds(0.75f);
        textBox.GetComponent<Text>().text = "I quickly became lost, but I eventually stumbled upon a clearing with a seemingly abandoned cabin in the distance";
        yield return new WaitForSeconds(8.75f);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(0.25f);

        // Line 5 of narration
        line05.Play();
        yield return new WaitForSeconds(0.5f);
        textBox.GetComponent<Text>().text = "As I approached, I heard sounds... sounds that made my skin crawl";
        yield return new WaitForSeconds(5.85f);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(0.5f);

        // Line 6 of narration
        line06.Play();
        yield return new WaitForSeconds(0.75f);
        textBox.GetComponent<Text>().text = "But nonetheless, I entered, having no idea what terrors were in store for me";
        yield return new WaitForSeconds(6.25f);
        textBox.GetComponent<Text>().text = "";

        // Make screen black, play thudsound, then after 1 second display loading text on black screen for 2 seconds, then load game scene
        blackScreen.SetActive(true);
        thudSound.Play();
        yield return new WaitForSeconds(1);
        loadingText.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
}
