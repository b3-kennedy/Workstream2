using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider)
        {
            Debug.Log("Pressed");
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider)
        {
            Debug.Log("Unpressed");
        }
    }
}
