using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflector : MonoBehaviour
{

    public Laser parentLaser;

    private void Start()
    {

    }

    private void Update()
    {
        if (parentLaser != null)
        {
            if (!parentLaser.fireLaser)
            {
                GetComponent<Laser>().fireLaser = false;
            }
        }

    }
}
