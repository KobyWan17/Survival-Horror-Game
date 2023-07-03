using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public GameObject gun;
    public GameObject muzzleFlash;
    public AudioSource gunshot;
    public AudioSource emptyGunshot;

    public bool isFiring = false;

    public float targetDistance;
    public int damage = 5;

    public GameObject ammoText;

    // Update is called once per frame
    void Update()
    {
        // If left button is clicked, the gun is active, gun is not currently firing, and player has ammo:
        if (Input.GetButtonDown("Fire1") && gun.activeInHierarchy && GlobalAmmo.ammoCount > 0)
        {
            if (isFiring == false)
            {
                // Decrement ammo by 1 and start coroutine to fire gun
                GlobalAmmo.ammoCount -= 1;
                StartCoroutine(FiringPistol());
            }
        }

        // If left button is clicked, the gun is active, gun is not currently firing, and the player has no ammo:
        if (Input.GetButtonDown("Fire1") && gun.activeInHierarchy && GlobalAmmo.ammoCount <= 0)
        {
            if (isFiring == false)
            {
                // Play empty gun sound
                emptyGunshot.Play();
                // If ammoText isn't currently displaying, display it when button is clicked
                if (!ammoText.activeInHierarchy)
                {
                    StartCoroutine(AmmoText());
                }
            }
        }
    }

    // Fires gun
    IEnumerator FiringPistol()
    {
        RaycastHit shot;
        isFiring = true;

        // If player clicks with crosshair aimed inside collider, activate DamageZombie script in ZombieDeath
        // This script decrements the health by damage variable, which in this case is 5
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            targetDistance = shot.distance;
            shot.transform.SendMessage("DamageZombie", damage, SendMessageOptions.DontRequireReceiver);
        }

        // Play firing animation, muzzle flash, and gunshot sound, then after .5 seconds turn muzzleflash off and allow player to fire again
        gun.GetComponent<Animation>().Play("PistolShot");
        muzzleFlash.SetActive(true);
        gunshot.Play();
        yield return new WaitForSeconds(0.5f);
        isFiring = false;
        muzzleFlash.SetActive(false);
    }

    // Display "no ammo" text, then after 2.5 seconds turn it off
    IEnumerator AmmoText()
    {
        ammoText.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        ammoText.SetActive(false);
    }
}
