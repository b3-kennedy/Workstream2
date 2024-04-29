using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDoor : MonoBehaviour
{
    public GameObject door;


    public void Open()
    {
        if (door.GetComponent<Animator>())
        {
            door.GetComponent<Animator>().SetTrigger("SlideUp");
        }
        else
        {
            door.SetActive(false);
        }
        
    }
}
