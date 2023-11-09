using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Animator cubeAnimator;
    private bool activated = false;
    private bool paused = false;
    private string SlideUp = "SlideUp";
    private string SlideDown = "SlideDown";

    private void Start() {
        cubeAnimator = GameObject.Find("Cube(5)").GetComponent<Animator>();
    }
    private IEnumerator Pause(string name){
        paused = true;
        yield return new WaitForSeconds(1);
        cubeAnimator.ResetTrigger(name);
        paused = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider && !activated && !paused)
        {
            // Debug.Log("Pressed");
            activated = true;
            cubeAnimator.SetTrigger(SlideUp);
            StartCoroutine(Pause(SlideUp));
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider && activated && !paused)
        {
            activated = false;
            // Debug.Log("Unpressed");
            cubeAnimator.SetTrigger(SlideDown);
            StartCoroutine(Pause(SlideDown));
        }
    }
}
