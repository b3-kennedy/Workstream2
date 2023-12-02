using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserActivation : MonoBehaviour
{
    public bool isActivated;
    public Laser parentLaser;
    public Renderer indicator;

    public Material red;
    public Material green;

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

        if (isActivated)
        {
            indicator.material = green;
        }
        else
        {
            indicator.material = red;
        }

    }
}
