using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieDeathScene2 : MonoBehaviour
{
    public int enemyHealth = 20;
    public GameObject enemy;
    public bool isDead;

    public AudioSource jumpMusic;

    // Decrement health by damage
    // Even though it does not directly appear to be being referenced, the SendMessage() in FirePistol calls it when needed
    void DamageZombie(int damage)
    {
        enemyHealth -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        // If enemy at 0 health or below:
        if (enemyHealth <= 0)
        {
            // Disable collider and AI
            this.GetComponent<ZombieAIScene2>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;

            // Set isDead to true, stop walking anim, play death anim, and stop music, then turn off zombie
            isDead = true;
            enemy.GetComponent<Animation>().Stop("Walk");
            enemy.GetComponent<Animation>().Play("ZombieDeath");
            jumpMusic.Stop();
            StartCoroutine(DeactivateZombie());
        }
    }

    IEnumerator DeactivateZombie()
    {
        yield return new WaitForSeconds(1.4f);
        gameObject.SetActive(false);
    }
}
