using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PressurePlateLift : MonoBehaviour
{
    public PressurePlateOnce plate;
    public float maxHeight;
    public float minHeight;
    public float speed;
    public bool rise;
    public bool fall;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (plate.isActivated)
        {
            rise = true;
        }

        if(!rise && plate.isActivated)
        {
            fall = true;
        }



    }

    void Rise()
    {
        if(Vector3.Distance(transform.position, new Vector3(transform.position.x, maxHeight, transform.position.z)) > .2f)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            rise = false;
        }
    }

    void Fall()
    {
        if (Vector3.Distance(transform.position, new Vector3(transform.position.x, minHeight, transform.position.z)) > .2f)
        {
            transform.Translate(-Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            rise = false;
        }
    }
}
