using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMaster : MonoBehaviour
{
    public Laser laser1;
    public Laser laser2;
    public Laser laser3;

    public Renderer indicator1;
    public Renderer indicator2;
    public Renderer indicator3;

    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate;

    public DoorButton button;

    public Material green;
    public Material red;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!button.isActivated)
        {
            if (laser1.isActive)
            {
                indicator1.material = red;
            }
            else
            {
                indicator1.material = green;
            }

            if (laser2.isActive)
            {
                indicator2.material = red;
            }
            else
            {
                indicator2.material = green;
            }

            if (laser3.isActive)
            {
                indicator3.material = red;
            }
            else
            {
                indicator3.material = green;
            }


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
