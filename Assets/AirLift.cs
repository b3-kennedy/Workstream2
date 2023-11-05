using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirLift : MonoBehaviour
{
    public float force;

    private void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (transform.parent.GetComponent<Windmill>().canRotate)
        {
            if (other.GetComponent<Rigidbody>())
            {
                other.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Impulse);
            }
        }

    }
}
