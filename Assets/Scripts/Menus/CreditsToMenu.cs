using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsToMenu : MonoBehaviour
{
    public GameObject logo;

    // Start coroutine to go to main menu
    void Start()
    {
        // Assign currentScene variable the current active scene, then set sceneName to the name of the currentScene scene
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        // Depending on which scene player is in, start coroutine to eventually send them back to menu
        if (sceneName == "Credits")
        {
            StartCoroutine(BackToMenuCredits());
        }

        if (sceneName == "Game Over")
        {
            StartCoroutine(BackToMenuGameOver());
        }

        if (sceneName == "Options")
        {
            StartCoroutine(BackToMenuOptions());
        }

        if (sceneName == "SplashScreen")
        {
            StartCoroutine(SplashToMenu());
        }
    }

    // Wait until credits are done rolling, then display logo for 5.25sec and return to menu from Credits scene
    IEnumerator BackToMenuCredits()
    {
        yield return new WaitForSeconds(25.5f);
        logo.SetActive(true);
        yield return new WaitForSeconds(5.25f);
        SceneManager.LoadScene(1);
    }

    // Send player back to menu from Game Over scene after 5 seconds
    IEnumerator BackToMenuGameOver()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(1);
    }

    // Send player back to menu from Options scene after 5 seconds
    IEnumerator BackToMenuOptions()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(1);
    }

    IEnumerator SplashToMenu()
    {
        yield return new WaitForSeconds(0.75f);
        logo.SetActive(true);
        yield return new WaitForSeconds(4.2f);
        logo.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(1);
    }
}
