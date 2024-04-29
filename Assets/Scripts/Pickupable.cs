using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    public bool destroyOnPickup;
    public bool dropOnSwitch;

    public void OnPickup()
    {
        if (destroyOnPickup)
        {
            GetComponent<Collider>().enabled = false;
        }

        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
