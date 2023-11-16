using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    public float hideTime;
    float timer;
    public GameObject objectToHide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(0).GetComponent<Windmill>().canRotate)
        {
            objectToHide.SetActive(false);
        }

        if (!transform.GetChild(0).GetComponent<Windmill>().canRotate)
        {
            objectToHide.SetActive(true);
        }
    }


}
