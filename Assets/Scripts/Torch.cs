using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public Material offMaterial;
    public Material onMaterial;
    public GameObject sphere;
    public GameObject torchLight;


    private void Start()
    {
        torchLight.SetActive(false);
    }

    public void TurnOn()
    {
        torchLight.SetActive(true);
        sphere.GetComponent<Renderer>().material = onMaterial;

    }

    public void TurnOff()
    {
        torchLight.SetActive(false);
        sphere.GetComponent<Renderer>().material = offMaterial;
    }
}
