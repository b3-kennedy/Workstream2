using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthDeposit : MonoBehaviour
{
    public LineRenderer earthTowerLr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EarthOrb"))
        {
            earthTowerLr.enabled = true;
            Destroy(other.gameObject);
        }
    }
}
