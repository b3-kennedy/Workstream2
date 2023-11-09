using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Animator cubeAnimator;
    private bool activated = false;

    private void Start() {
        cubeAnimator = GameObject.Find("Cube(5)").GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider)
        {
            Debug.Log("Pressed");
            activated = true;
            cubeAnimator.SetTrigger("SlideUp");
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider && activated)
        {
            activated = false;
            Debug.Log("Unpressed");
            cubeAnimator.SetTrigger("SlideDown");
        }
    }
}
