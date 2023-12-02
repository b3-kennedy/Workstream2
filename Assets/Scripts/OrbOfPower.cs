using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbOfPower : MonoBehaviour
{

    public Transform sphere;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<LineRenderer>().useWorldSpace = true;
        GetComponent<LineRenderer>().SetPosition(1, sphere.position);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GetComponent<LineRenderer>().enabled)
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
        }
        

    }
}
