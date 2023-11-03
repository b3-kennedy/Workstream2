using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillArea : MonoBehaviour
{
    public GameObject waterObj;
    GameObject water;
    public float fillSpeed;
    public bool rise;
    public float timeToRise;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(water != null)
        {
            if(water.transform.localScale.y < GetComponent<BoxCollider>().size.y*2)
            {
                if (rise)
                {
                    timer += Time.deltaTime;

                    water.transform.localScale = new Vector3(water.transform.localScale.x, water.transform.localScale.y + fillSpeed * Time.deltaTime, water.transform.localScale.z);

                    if (timer >= timeToRise)
                    {
                        rise = false;
                        timer = 0;
                    }
                }
            }
        }

    }

    public void Fill()
    {
        if(transform.childCount <= 0)
        {
            water = Instantiate(waterObj, new Vector3(transform.position.x, transform.position.y- GetComponent<BoxCollider>().size.y / 2, transform.position.z), Quaternion.identity);
            water.transform.SetParent(transform);
            water.transform.localScale = new Vector3(GetComponent<BoxCollider>().size.x, .01f, GetComponent<BoxCollider>().size.z);
            rise = true;
        }
        else
        {
            rise = true;
        }

    }
}
