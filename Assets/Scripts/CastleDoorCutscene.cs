using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleDoorCutscene : MonoBehaviour
{
    public GameObject castleDoor;


    public void DeactivateCam()
    {
        gameObject.SetActive(false);
    }

    public void OpenDoor()
    {
        castleDoor.SetActive(false);
    }
}
