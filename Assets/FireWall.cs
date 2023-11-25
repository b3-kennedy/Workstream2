using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Interact>())
        {
            if (other.GetComponent<Interact>().holdPoint.GetChild(0).GetComponent<Fuel>())
            {
                Destroy(other.GetComponent<Interact>().holdPoint.GetChild(0).gameObject);
            }
        }
    }
}
