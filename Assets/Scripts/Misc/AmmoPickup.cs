using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public GameObject ammoMarker;
    public AudioSource ammoPickup;
    public static bool hasAmmo;

    // When player walks over ammobox, play pickup sound, add 10 to ammo, set hasAmmo to true, and start coroutine to deactivate ammobox
    void OnTriggerEnter()
    {
        ammoPickup.Play();
        GlobalAmmo.ammoCount += 10;
        hasAmmo = true;
        StartCoroutine(EarlyAmmoSound());
    }

    // To make audio sync with object deactivation, wait 0.2 seconds to deactivate ammobox and ammomarker after playing soundfx
    IEnumerator EarlyAmmoSound()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
        ammoMarker.SetActive(false);
    }
}
