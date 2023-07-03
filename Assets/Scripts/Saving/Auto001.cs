using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto001 : MonoBehaviour
{
    // Sets int to current scene (2/Scene001), allowing this scene to be loaded back into from menu loadButton
    void Start()
    {
        PlayerPrefs.SetInt("AutoSave", 2);
    }
}
