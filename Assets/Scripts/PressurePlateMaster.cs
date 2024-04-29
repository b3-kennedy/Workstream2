using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PressurePlateMaster : MonoBehaviour
{

    public PressurePlate[] pps;

    public Renderer[] indicators;

    public Material green;
    public Material red;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < pps.Length; i++)
        {
            if (pps[i].activated)
            {
                indicators[i].material = green;
            }
            else
            {
                indicators[i].material = red;
            }
        }
    }
}
