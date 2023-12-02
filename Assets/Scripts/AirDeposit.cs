using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDeposit : MonoBehaviour
{
    public LineRenderer towerLr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AirOrb"))
        {
            towerLr.enabled = true;
            Destroy(other.gameObject);
        }
    }
}
