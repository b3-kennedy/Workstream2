using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyantPlatform : Buoyancy
{
    public float playerMultiplier;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider)
        {
            buoyancyForce *= playerMultiplier;
            playerOnPlatform = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider)
        {
            buoyancyForce = baseBuoyancyForce;
            playerOnPlatform = false;
        }
    }
}
