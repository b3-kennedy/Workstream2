using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirLift : MonoBehaviour
{
    public float force;
    public Transform lauchPoint;
    public bool send;
    Collider obj;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.parent.GetComponent<Windmill>().canRotate)
        {
            if (other.GetComponent<Rigidbody>())
            {
                obj = other;
                send = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {



            send = false;

            
        }
    }


    private void FixedUpdate()
    {
        if (send)
        {
            obj.GetComponent<Rigidbody>().AddForce(lauchPoint.up * force, ForceMode.Impulse);
        }
    }
}
