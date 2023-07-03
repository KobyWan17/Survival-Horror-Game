using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupJumpTrigger004 : MonoBehaviour
{
    public GameObject jumpActivator1;
    public GameObject jumpActivator2;
    public GameObject jumpActivator3;
    public AudioSource cupJump;

    // When trigger collider is entered, disable collider, enable jumpActivators, and start coroutine to disable them
    void OnTriggerEnter()
    {
        cupJump.Play();
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        jumpActivator1.SetActive(true);
        jumpActivator2.SetActive(true);
        jumpActivator3.SetActive(true);
        StartCoroutine(DeactivateActivator());
    }

    // After 0.5 seconds, disable jumpActivators
    IEnumerator DeactivateActivator()
    {
        yield return new WaitForSeconds(0.5f);
        jumpActivator1.SetActive(false);
        jumpActivator2.SetActive(false);
        jumpActivator3.SetActive(false);
    }
}
