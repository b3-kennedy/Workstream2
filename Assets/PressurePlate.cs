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
    public GameObject door;



    private void Start() {
        //cubeAnimator = GameObject.Find("Cube(5)").GetComponent<Animator>();
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
            if(cubeAnimator != null)
            {
                cubeAnimator.SetTrigger(SlideUp);
                StartCoroutine(Pause(SlideUp));
                
            }
            else
            {
                door.SetActive(false);
            }

        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider && activated && !paused)
        {
            activated = false;
            if(cubeAnimator != null)
            {
                // Debug.Log("Unpressed");
                cubeAnimator.SetTrigger(SlideDown);
                StartCoroutine(Pause(SlideDown));
                
            }
            else
            {
                door.SetActive(true);
            }

        }
    }
}
