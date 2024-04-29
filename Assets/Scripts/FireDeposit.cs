using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDeposit : MonoBehaviour
{
    public LineRenderer fireTowerLr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FireOrb"))
        {
            fireTowerLr.enabled = true;
            Destroy(other.gameObject);
        }
    }
}
