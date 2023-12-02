using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDeposit : MonoBehaviour
{
    public LineRenderer finalTowerLr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinalOrb"))
        {
            finalTowerLr.enabled = true;
            GameManager.Instance.FinalCutscene();
            Destroy(other.gameObject);
        }
    }
}
