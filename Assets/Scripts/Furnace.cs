using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour
{
    public Transform fireSlot;
    public Transform woodSlot;
    public Transform output;

    public GameObject charcoal;

    public bool fire;
    public bool wood;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fireSlot.childCount > 0)
        {
            if (fireSlot.GetChild(0).GetComponent<FireOrb>())
            {
                fire = true;
            }
        }

        if(woodSlot.childCount > 0)
        {
            if (woodSlot.GetChild(0).GetComponent<Wood>())
            {
                wood = true;
            }
        }

        if(wood && fire)
        {
            GameObject charc = Instantiate(charcoal, output.position, Quaternion.identity);
            charc.GetComponent<Rigidbody>().AddForce(-transform.right * 5, ForceMode.Impulse);
            Destroy(woodSlot.GetChild(0).gameObject);
            wood = false;
        }
    }
}
