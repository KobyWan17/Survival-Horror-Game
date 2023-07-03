using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingSequence007 : MonoBehaviour
{
    public GameObject textBox;
    
    // Music AudioSources
    public AudioSource backgroundMusic;
    public AudioSource chaseMusic;

    // Dialouge AudioSources
    public AudioSource heavyBreathing;
    public AudioSource demonLine01;
    public AudioSource demonLine02;
    public AudioSource demonLine03;
    public AudioSource finalBang;
    public AudioSource creepyMusic;

    // Variables for wallDoor opening
    public GameObject wallDoor;
    public GameObject wallDoorBlock;
    public AudioSource doorScrape;

    public GameObject fadeScreenOut;
    public GameObject continuedText;

    // When player crosses trigger in secret room:
    void OnTriggerEnter()
    {
        // Disable trigger collider, play door closing anim/sound, lock player in room, and start coroutine for ending 
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        wallDoor.GetComponent<Animation>().Play("SecretDoorCloseAnim");
        doorScrape.Play();
        wallDoorBlock.SetActive(true);
        StartCoroutine(EndingDialogue());
    }

    // 
    IEnumerator EndingDialogue()
    {
        // Stop background music, then after 5sec stop chase music and start heavy breathing & creepy music
        backgroundMusic.Stop();
        yield return new WaitForSeconds(5);
        chaseMusic.Stop();
        heavyBreathing.Play();
        creepyMusic.Play();

        // Then after 7 seconds of breathing, play demon's lines over next 11.5 seconds
        yield return new WaitForSeconds(7);
        demonLine01.Play();
        yield return new WaitForSeconds(0.5f);
        textBox.GetComponent<Text>().text = "Oh... you thought you'd escaped?";
        yield return new WaitForSeconds(3f);
        demonLine02.Play();
        textBox.GetComponent<Text>().text = "*laughing softly*";
        yield return new WaitForSeconds(3f);
        demonLine03.Play();
        yield return new WaitForSeconds(0.5f);
        textBox.GetComponent<Text>().text = "Oh honey... this is just the beginning";
        yield return new WaitForSeconds(4.5f);
        textBox.GetComponent<Text>().text = "";

        // After demon lines end, play loudNoise and fade screen to black, then display continuedText for 3 seconds, and then roll credits
        finalBang.Play();
        fadeScreenOut.SetActive(true);
        yield return new WaitForSeconds(3);
        continuedText.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(6);
    }
}
