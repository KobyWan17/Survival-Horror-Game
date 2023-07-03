using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAnimations : MonoBehaviour
{
    public int lightMode;
    public GameObject flameLight;

    // Update is called once per frame
    void Update()
    {
        // Once the coroutines end and lightMode goes back to 0, start coroutines again
        if (lightMode == 0 && gameObject.CompareTag("Fireplace")) // For fireplace
        {
            StartCoroutine(AnimateFireplaceLight());
        }
        else if (lightMode == 0 && !gameObject.CompareTag("Fireplace")) // For torches (not fireplace)
        {
            StartCoroutine(AnimateTorchLight());
        }
    }

    // Make torch lights flicker
    IEnumerator AnimateTorchLight()
    {
        // Set lightMode to random value between 1 and 3
        lightMode = Random.Range(1, 4);

        // According to what intensity it is, play the anim that sets the corresponding intensity in the scene
        // Ex: If lightmode is 1, then play the anim that sets the intensity to flicker at normal light (2 is brighter, 3 is darker)
        if (lightMode == 1)
        {
            flameLight.GetComponent<Animation>().Play("TorchAnim1");
        }
        else if (lightMode == 2)
        {
            flameLight.GetComponent<Animation>().Play("TorchAnim2");
        }
        else if (lightMode == 3)
        {
            flameLight.GetComponent<Animation>().Play("TorchAnim3");
        }

        // After 1 seconds, reset lightMode to 0 and run through code again every second
        yield return new WaitForSeconds(.99f);
        lightMode = 0;
    }

    // Does the same thing as AnimateTorchLight, except without the weaker light option (better simulates the fireplace)
    IEnumerator AnimateFireplaceLight()
    {
        lightMode = Random.Range(1, 3);
        if (lightMode == 1)
        {
            flameLight.GetComponent<Animation>().Play("TorchAnim1");
        }
        else if (lightMode == 2)
        {
            flameLight.GetComponent<Animation>().Play("TorchAnim2");
        }

        yield return new WaitForSeconds(.99f);
        lightMode = 0;
    }
}
