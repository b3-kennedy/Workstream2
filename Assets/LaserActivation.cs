using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserActivation : MonoBehaviour
{
    public bool isActivated;
    public Laser parentLaser;

    private void Update()
    {
        if(parentLaser != null)
        {
            if (!parentLaser.fireLaser)
            {
                isActivated = false;
            }

            if(parentLaser.button != GetComponent<Collider>())
            {
                isActivated = false;
            }
        }

    }
}
