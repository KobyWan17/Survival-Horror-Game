using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroSequencing : MonoBehaviour
{
    public GameObject placeDisplay;
    public GameObject dateDisplay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisplaySequence());
    }

    // After 2 seconds, display forest name, then after another 2 seconds display the date for 1 second
    // Displays have animation in scene that will make them fade out over time, so no need to script it in here
    IEnumerator DisplaySequence()
    {
        yield return new WaitForSeconds(2);
        placeDisplay.SetActive(true);
        yield return new WaitForSeconds(2);
        dateDisplay.SetActive(true);
        yield return new WaitForSeconds(1);
    }
}
