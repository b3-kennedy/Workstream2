using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PylonWire : MonoBehaviour
{
    public LineRenderer lr1;
    public LineRenderer lr2;

    public Transform wire1Destination;
    public Transform wire2Destination;


    // Start is called before the first frame update
    void Start()
    {
        lr1.SetPosition(0, lr1.transform.position);
        lr2.SetPosition(0, lr2.transform.position);

        lr1.SetPosition(1, wire1Destination.position);
        lr2.SetPosition(1, wire2Destination.position);
    }

}
