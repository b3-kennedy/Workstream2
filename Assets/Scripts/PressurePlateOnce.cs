using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PressurePlateOnce : MonoBehaviour
{

    public bool isActivated;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider)
        {
            // Debug.Log("Pressed");

            if (other.transform.GetComponent<FirstPersonMovement>() || other.transform.GetComponent<Rigidbody>().mass > 3)
            {
                if (!isActivated)
                {

                    isActivated = true;
                    
                }
                else
                {
                    isActivated = false;
                }
            }




        }
    }


}
