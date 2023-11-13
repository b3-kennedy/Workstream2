using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDoor : MonoBehaviour
{
    public GameObject door;


    public void Open()
    {
        door.GetComponent<Animator>().SetTrigger("SlideUp");
    }
}
