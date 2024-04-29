using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{

    public GameObject[] deactivatableObjects;
    public GameObject[] activatableObjects;
    public bool isActivated;

    public void Activated()
    {
        isActivated = true;
        foreach (GameObject obj in deactivatableObjects)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in activatableObjects)
        {
            obj.SetActive(true);
        }
    }
}
