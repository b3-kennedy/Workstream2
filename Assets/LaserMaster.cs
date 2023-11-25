using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMaster : MonoBehaviour
{
    public Laser laser1;
    public Laser laser2;
    public Laser laser3;

    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate;

    public DoorButton button;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!button.isActivated)
        {
            if (laser1.isActive || laser2.isActive || laser3.isActive)
            {
                foreach (GameObject obj in objectsToActivate)
                {
                    obj.SetActive(true);
                }


            }

            if (!laser1.isActive && !laser2.isActive && !laser3.isActive)
            {
                foreach (GameObject obj in objectsToDeactivate)
                {
                    obj.SetActive(false);
                }
            }
        }

    }
}
