using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonLift : MonoBehaviour
{

    public LaserActivation button;
    public float minHeight;
    public float maxHeight;
    public float speed;
    bool rise;


    // Update is called once per frame
    void Update()
    {
        if (button.isActivated)
        {
            Rise();
        }
        else
        {
            Fall();
        }
    }

    void Rise()
    {
        if(transform.localPosition.y <= minHeight)
        {
            rise = true;
        }

        if (rise && transform.localPosition.y < maxHeight)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        
    }

    void Fall()
    {
        if (transform.localPosition.y >= minHeight)
        {
            rise = false;
            
        }

        if(!rise && transform.localPosition.y > minHeight)
        {
            transform.Translate(-Vector3.up * speed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonMovement>())
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FirstPersonMovement>())
        {
            other.transform.SetParent(null);
        }
    }
}
