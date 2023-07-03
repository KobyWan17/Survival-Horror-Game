using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    public static float distanceFromTarget;
    public float toTarget;

    // Update is called once per frame
    void Update()
    {
        // Creates a Raycast variable called hit
        RaycastHit hit;

        // If the raycast (going forward from player's position) intersects any object, store that value in hit
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            toTarget = hit.distance;
            distanceFromTarget = toTarget;
        }
    }
}
