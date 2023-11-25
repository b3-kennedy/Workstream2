using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer lr;
    public Transform start;
    public float range;
    public bool isActive;
    RaycastHit hit;
    float vineTimer;
    public float vineDestroyTime;
    public float rockMineTime;
    float rockTimer;
    GameObject vine;

    // Start is called before the first frame update
    void Start()
    {
        lr.SetPosition(0, start.position);
    }

    // Update is called once per frame
    void Update()
    {
        LaserRaycast();
        VineDestroy();



    }

    void LaserRaycast()
    {
        if (lr.gameObject.activeSelf)
        {
            if (Physics.Raycast(start.position, start.forward, out hit, range))
            {
                if (hit.collider)
                {
                    lr.SetPosition(1, hit.point);

                    if (hit.transform.CompareTag("ClimbableVines"))
                    {
                        vine = hit.collider.gameObject;
                    }
                    else if (hit.transform.CompareTag("Rock"))
                    {
                        HitRock();
                    }


                    if (hit.transform.CompareTag("LaserTarget"))
                    {
                        isActive = true;
                    }
                    else
                    {
                        isActive = false;
                    }
                }


            }
            else
            {
                lr.SetPosition(1, start.forward * range);
            }
        }

    }

    void HitRock()
    {
        rockTimer += Time.deltaTime;
        if(rockTimer >= rockMineTime)
        {
            hit.transform.localScale *= 0.9f;
            hit.transform.GetComponent<Rigidbody>().mass *= 0.9f;

            if (hit.transform.localScale.x <= 0.3f)
            {
                hit.transform.gameObject.layer = 3;
                var pickupable = hit.transform.AddComponent<Pickupable>();
                pickupable.destroyOnPickup = true;
                pickupable.dropOnSwitch = true;
            }

            GameObject rock = Instantiate(hit.collider.gameObject, hit.point, Quaternion.identity);
            rock.GetComponent<Rigidbody>().isKinematic = false;
            rock.transform.localScale *= 0.1f;
            rock.GetComponent<Rigidbody>().mass *= 0.1f;
            rock.layer = 3;
            var pickupdable = rock.AddComponent<Pickupable>();
            pickupdable.destroyOnPickup = true;
            pickupdable.dropOnSwitch = true;

            rockTimer = 0;
        }



    }


    void VineDestroy()
    {
        if (vine)
        {
            vineTimer += Time.deltaTime;
            if(vineTimer >= vineDestroyTime)
            {
                Destroy(vine);
                vineTimer = 0;
            }
        }
    }
}
