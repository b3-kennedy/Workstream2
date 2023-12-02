using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PressurePlateScreen : MonoBehaviour
{

    public float minMass;
    public TextMeshPro massReq;
    public TextMeshPro currentMass;
    public WeightTrigger plate;
    public GameObject door;

    public Material green;
    public Material red;
    public Renderer indicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        massReq.text = "Mass Requirement: " + minMass.ToString();
        currentMass.text = "Current Mass: " + plate.weight.ToString();

        if (plate.weight >= minMass)
        {
            door.SetActive(false);
            indicator.material = green;
        }
        else
        {
            door.SetActive(true);
            indicator.material = red;
        }
    }
}
