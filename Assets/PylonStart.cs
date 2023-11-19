using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PylonStart : MonoBehaviour
{
    public LineRenderer lr1;
    public LineRenderer lr2;
    public LineRenderer lr3;
    public LineRenderer lr4;

    public Transform lr1End;
    public Transform lr2End;
    public Transform lr3End;
    public Transform lr4End;


    // Start is called before the first frame update
    void Start()
    {
        lr1.SetPosition(0, transform.position);
        lr2.SetPosition(0, transform.position);
        lr3.SetPosition(0, transform.position);
        lr4.SetPosition(0, transform.position);

        lr1.SetPosition(1, lr1End.position);
        lr2.SetPosition(1, lr2End.position);
        lr3.SetPosition(1, lr3End.position);
        lr4.SetPosition(1, lr4End.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
