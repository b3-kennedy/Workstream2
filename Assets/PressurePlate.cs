using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Animator cubeAnimator;
    public bool activated = false;
    private bool paused = false;
    private string SlideUp = "SlideUp";
    private string SlideDown = "SlideDown";
    public GameObject door;
    public bool opposite;
    public float minMass;
    public AudioClip doorClang;



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

            if(other.transform.GetComponent<FirstPersonMovement>() || other.transform.GetComponent<Rigidbody>().mass > minMass)
            {
                activated = true;
                if (cubeAnimator != null)
                {
                    cubeAnimator.SetTrigger(SlideUp);
                    StartCoroutine(Pause(SlideUp));

                }
                else
                {
                    if (opposite)
                    {
                        door.SetActive(true);
                        
                    }
                    else
                    {
                        door.SetActive(false);
                        AudioSource.PlayClipAtPoint(doorClang, door.transform.position);
                    }
                }
            }


        }
    }

    private void OnCollisionExit(Collision other)
    {

        if (other.transform.GetComponent<FirstPersonMovement>() || other.transform.GetComponent<Rigidbody>().mass > 3)
        {
            if (other.collider && activated && !paused)
            {
                activated = false;
                if (cubeAnimator != null)
                {
                    // Debug.Log("Unpressed");
                    cubeAnimator.SetTrigger(SlideDown);
                    StartCoroutine(Pause(SlideDown));

                }
                else
                {
                    if (opposite)
                    {
                        door.SetActive(false);
                    }
                    else
                    {
                        door.SetActive(true);
                    }

                }

            }
        }

    }
}
