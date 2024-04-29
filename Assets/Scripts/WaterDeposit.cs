using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDeposit : MonoBehaviour
{
    public LineRenderer waterTowerLr;
    public GameObject tip;
    public GameObject portal1;
    public GameObject portal2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaterOrb"))
        {
            waterTowerLr.enabled = true;
            Destroy(other.gameObject);
            tip.SetActive(true);
            portal1.SetActive(true);
            portal2.SetActive(true);
        }
    }
}
