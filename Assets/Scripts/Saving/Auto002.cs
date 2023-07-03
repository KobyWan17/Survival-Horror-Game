using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto002 : MonoBehaviour
{
    // Sets int to current scene (5/Scene002), allowing this scene to be loaded back into from menu loadButton
    void Start()
    {
        PlayerPrefs.SetInt("AutoSave", 5);
    }
}
