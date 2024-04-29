using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoEarthZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EarthOrb>())
        {
            Destroy(other.gameObject);
        }
    }
}
