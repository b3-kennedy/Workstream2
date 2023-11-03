using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyantPlatform : Buoyancy
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider)
        {
            buoyancyForce *= 2;
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
