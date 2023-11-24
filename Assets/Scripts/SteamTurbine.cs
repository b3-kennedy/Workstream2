using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SteamTurbine : MonoBehaviour
{
    Transform waterSlot;
    Transform fireSlot;
    Transform woodSlot;

    public GameObject titleText;
    public GameObject ingredientsText;
    public GameObject waterText;
    public GameObject fireText;
    public GameObject woodText;

    public GameObject screen;
    public Material green;
    Material red;

    public bool water;
    public bool fire;
    public bool wood;

    public float onDuration;
    public float burnTimer;

    public GameObject door;
    public GameObject[] activatableObjectsOnComplete;
    public GameObject[] deactivatableObjectsOnComplete;

    bool activated;


    // Start is called before the first frame update
    void Start()
    {
        waterSlot = transform.GetChild(2).GetChild(0).GetChild(0);
        fireSlot = transform.GetChild(1).GetChild(0).GetChild(0);
        woodSlot = transform.GetChild(0).GetChild(0).GetChild(0);
        red = screen.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (water && wood && fire)
        {
            if(woodSlot.transform.childCount > 0)
            {
                onDuration = woodSlot.transform.GetChild(0).GetComponent<Fuel>().duration;

                burnTimer += Time.deltaTime;
                if (burnTimer >= onDuration)
                {
                    if (woodSlot.transform.childCount > 0)
                    {
                        Destroy(woodSlot.transform.GetChild(0).gameObject);
                    }

                    wood = false;
                    screen.GetComponent<Renderer>().material = red;
                    woodText.SetActive(true);
                    ingredientsText.SetActive(true);

                }
            }
            

        }


        if (waterSlot.childCount > 0)
        {
            if (waterSlot.GetChild(0).GetComponent<WaterOrb>())
            {
                water = true;
                waterText.SetActive(false);
            }
            else if (waterSlot.GetChild(0).GetComponent<SteamOrb>())
            {
                water = true;
                fire = true;
                wood = true;
            }
        }

        if (fireSlot.childCount > 0)
        {
            if (fireSlot.GetChild(0).GetComponent<FireOrb>())
            {
                fire = true;
                fireText.SetActive(false);
            }
            else if (fireSlot.GetChild(0).GetComponent<SteamOrb>())
            {
                water = true;
                fire = true;
                wood = true;
            }
        }

        if (woodSlot.childCount > 0)
        {
            if (woodSlot.GetChild(0).GetComponent<Wood>())
            {
                wood = true;
                woodText.SetActive(false);
            }
            else if (woodSlot.GetChild(0).GetComponent<SteamOrb>())
            {
                water = true;
                fire = true;
                wood = true;
            }
            else if (woodSlot.GetChild(0).GetComponent<Fuel>())
            {
                wood = true;
                woodText.SetActive(false);
            }
        }

        if(water && fire && wood)
        {
            if (!activated)
            {
                if (door != null)
                {
                    door.GetComponent<Animator>().SetBool("open", true);
                }

                foreach (var obj in activatableObjectsOnComplete)
                {
                    obj.SetActive(true);
                }

                foreach (var obj in deactivatableObjectsOnComplete)
                {
                    obj.SetActive(false);
                }

                titleText.SetActive(false);
                ingredientsText.SetActive(false);
                screen.GetComponent<Renderer>().material = green;
                fireText.SetActive(false);
                waterText.SetActive(false);
                woodText.SetActive(false);
                activated = true;
            }


        }
    }
}
