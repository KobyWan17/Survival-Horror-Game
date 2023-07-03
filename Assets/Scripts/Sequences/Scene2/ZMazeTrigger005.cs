using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZMazeTrigger005 : MonoBehaviour
{
    public GameObject zombie01;
    public GameObject zombie02;

    // When player enters trigger, disabled trigger, activate first zombie, then start coroutine for second zombie
    void OnTriggerEnter()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(Zombie01Activate());
        StartCoroutine(Zombie02Activate());
    }

    // After 10 seconds, activate second zombie
    IEnumerator Zombie02Activate()
    {
        yield return new WaitForSeconds(10);
        zombie02.SetActive(true);
    }

    // After 2 seconds, activate first zombie
    IEnumerator Zombie01Activate()
    {
        yield return new WaitForSeconds(2);
        zombie01.SetActive(true);
    }
}
