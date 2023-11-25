using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDeposit : MonoBehaviour
{
    public LineRenderer waterTowerLr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaterOrb"))
        {
            waterTowerLr.enabled = true;
            Destroy(other.gameObject);
        }
    }
}
