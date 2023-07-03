using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAIScene2 : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public float enemySpeed;
    public bool attackTrigger = false; // Is true if player is within range of zombie
    public bool isAttacking = false;

    public float distance;

    // Audio of player taking damage
    public AudioSource hurtSound01;
    public AudioSource hurtSound02;
    public AudioSource hurtSound03;
    public int hurtGen;

    // Red flash on screen when hurt
    public GameObject hurtFlash;

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(enemy.transform.position, player.transform.position);
        // Make it constantly look at player
        transform.LookAt(player.transform);
        Attack();

        // If player is w/i 2, attackTrigger is true, if not, then false
        if (distance <= 2f)
        {
            attackTrigger = true;
        }
        else
        {
            attackTrigger = false;
        }
    }

    void Attack()
    {
        // If zombie isn't attacking or within range, and isn't dead:
        if (attackTrigger == false && distance >= 1.5f && enemy.GetComponent<ZombieDeathScene2>().isDead == false)
        {
            // Set enemy speed, play walking anim, and make it move towards player
            enemySpeed = 0.0022f;
            enemy.GetComponent<Animation>().Play("Walk");
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed);
        }

        // If zombie is within range and isn't attacking, attack and deal damage
        if (attackTrigger == true && isAttacking == false && distance <= 2f)
        {
            enemySpeed = 0;
            enemy.GetComponent<Animation>().Play("ZombieAttack");
            StartCoroutine(InflictDamage());
        }
    }

    // Allow enemy to attack, deal damage, and play hurt audio/flash
    IEnumerator InflictDamage()
    {
        isAttacking = true;

        // Generates random value for hurtGen
        hurtGen = Random.Range(0, 3);

        // Depending on which number is generated, play different corresponding hurt sounds
        if (hurtGen == 1)
        {
            hurtSound01.Play();
        }
        else if (hurtGen == 2)
        {
            hurtSound02.Play();
        }
        else if (hurtGen == 3)
        {
            hurtSound03.Play();
        }

        // When player is hurt, flash red screen for 0.5 and then deactivate it
        hurtFlash.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        hurtFlash.SetActive(false);

        // Wait 0.6 seconds, deal damage, and then after 0.4 allow loop to start again
        yield return new WaitForSeconds(0.6f);
        GlobalHealth.health -= 5;
        yield return new WaitForSeconds(0.4f);
        isAttacking = false;
    }
}
