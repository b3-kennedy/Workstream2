using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightTrigger : MonoBehaviour
{
    public float weight;
    public List<GameObject> objects;
    Collider col;
    public bool startWaitTimer;
    float timer;

    float minX;
    float minY;
    float minZ;

    float maxX;
    float maxY; 
    float maxZ;

    private void Start()
    {
        col = GetComponent<Collider>();

        minX = col.bounds.min.x;
        minY = col.bounds.min.y;
        minZ = col.bounds.min.z;

        maxX = col.bounds.max.x;
        maxY = col.bounds.max.y;
        maxZ = col.bounds.max.z;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            //if (other.GetComponent<FirstPersonMovement>())
            //{
            //    weight += 50;
            //}

            if (!objects.Contains(other.gameObject))
            {
                objects.Add(other.gameObject);
                weight += other.GetComponent<Rigidbody>().mass;
                startWaitTimer = true;
                
            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.GetComponent<FirstPersonMovement>())
        //{
        //    weight -= 50;
        //}
    }

    private void Update()
    {
        CheckBox();



    }

    void CheckBox()
    {
        if(objects.Count > 0)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (!CheckBounds(objects[i]))
                {
                    weight -= objects[i].GetComponent<Rigidbody>().mass;
                    objects.RemoveAt(i);
                    break;

                }
            }
        }

    }


    bool CheckBounds(GameObject obj)
    {
        Vector3 pos = obj.transform.position;
        return ((pos.x >= minX && pos.x <= maxX) && (pos.z >= minZ && pos.z <= maxZ));


        
    }



}
