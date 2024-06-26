using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public Vector3 rotation;
    public float range;
    public virtual void OnPickUp() 
    {
        transform.localRotation = Quaternion.Euler(rotation);
    }

    public virtual void Use() { }

    public virtual void UI() { }
}
