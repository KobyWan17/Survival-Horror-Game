using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalHealth : MonoBehaviour
{
    public static int health = 20;
    public int internalHealth;

    // Update is called once per frame
    void Update()
    {
        // If player dies (health <= 0), load GameOver scene
        internalHealth = health;
        if (health <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
