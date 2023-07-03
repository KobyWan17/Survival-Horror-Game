using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour
{
    public static int ammoCount;
    public GameObject ammoDisplay;
    public int internalAmmo;

    // Update is called once per frame
    void Update()
    {
        // internalAmmo is equal to ammoCount, and the text of ammoDisplay updated to whatever the ammoCount variable is
        internalAmmo = ammoCount;
        ammoDisplay.GetComponent<Text>().text = "" + ammoCount;
    }
}
