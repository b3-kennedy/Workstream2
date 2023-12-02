using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    public Transform endPoint;
    public Transform startPoint;

    public Transform fireSlot;
    public Transform coalSlot;

    bool activated;

    public float speed;
    bool finished;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            if (fireSlot.childCount > 0 && coalSlot.childCount > 0)
            {
                activated = true;
            }
        }


        Move();
    }

    private void Move()
    {
        if (activated)
        {
            Vector3 dir = (endPoint.position - startPoint.position).normalized;


            if(Vector3.Distance(transform.position, endPoint.position) > 0.5f)
            {
                transform.Translate(dir * speed * Time.deltaTime);
                
            }
            else
            {
                finished = true;
                activated = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonMovement>())
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FirstPersonMovement>())
        {
            other.transform.SetParent(null);
        }
    }
}
