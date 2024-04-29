using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour
{

    public float baseBuoyancyForce = 12.72f;
    protected float buoyancyForce;
    public bool inWater;
    protected bool playerOnPlatform;
    Rigidbody rb;
    bool changedDrag;

    private void Start()
    {
        buoyancyForce = baseBuoyancyForce;
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaterArea"))
        {
            changedDrag = false;
            inWater = true;
            rb.drag = 5;
            
        }
    }

    private void Update()
    {
        if(!inWater && !changedDrag)
        {
            rb.drag = 0.05f;
            changedDrag = true;
        }
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.collider.CompareTag("Player"))
    //    {
    //        buoyancyForce *= 2;
    //        playerOnPlatform = true;
    //    }
    //}

    //private void OnCollisionExit(Collision other)
    //{
    //    if (other.collider.CompareTag("Player"))
    //    {
    //        buoyancyForce = baseBuoyancyForce;
    //        playerOnPlatform = false;
    //    }
    //}

    private void FixedUpdate()
    {
        if (inWater)
        {
            rb.AddForce(Vector3.up * buoyancyForce, ForceMode.Acceleration);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WaterArea"))
        {
            inWater = false;
            rb.drag = 0.05f;
        }
    }
}
