using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject loadingText;
    public AudioSource buttonClick;

    public GameObject loadButton;
    public int loadInt;

    void Start()
    {
        // loadInt variable is set to what AutoSave was last set to (number is the same as whatever scene we are loading into)
        loadInt = PlayerPrefs.GetInt("AutoSave");
        // If loadInt is > 0 (We have a loaded scene), display loadButton (don't display if this is the first time player has run game)
        if (loadInt > 0)
        {
            loadButton.SetActive(true);
        }
    }

    // Fade screen to black, play bang sound, then after 3 seconds display loading text on black screen for 2 sec, then load scene001
    IEnumerator NewGameStart()
    {
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(3);
        loadingText.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(4);
    }
    // Fade screen to black, play bang sound, then after 3 seconds display loading text on black screen for 2 sec, then load saved scene
    IEnumerator LoadGameStart()
    {
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(3);
        loadingText.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(loadInt);
    }

    // Fade screen to black, play bang sound, then after 3 seconds display loading text on black screen for 2 sec, then play Credits
    IEnumerator LoadCredits()
    {
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(3);
        loadingText.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(6);
    }

    // Fade screen to black, play bang sound, then after 3 seconds display loading text on black screen for 2 sec, then load Options scene
    IEnumerator LoadOptions()
    {
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(3);
        loadingText.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(7);
    }

    // Start coroutine to start new game when clicked
    public void NewGameButton()
    {
        StartCoroutine(NewGameStart());
    }

    // Start coroutine to load saved game when clicked
    public void LoadGameButton()
    {
        StartCoroutine(LoadGameStart());
    }

    // Start coroutine to load credits when clicked
    public void CreditsButton()
    {
        StartCoroutine(LoadCredits());
    }

    // Start coroutine to load Options scene when clicked
    public void OptionsButton()
    {
        StartCoroutine(LoadOptions());
    }

    // Send player to GitHub account when clicked
    public void WebsiteButton()
    {
        Application.OpenURL("https://github.com/KobyWan17");
    }
}
