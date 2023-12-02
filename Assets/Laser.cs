using System.Collections;
using System.Collections.Generic;
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
    public bool fireLaser;
    public Collider reflector;
    [HideInInspector] public Collider button;

    // Start is called before the first frame update
    void Start()
    {
        lr.useWorldSpace = true;
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, start.position);
        LaserRaycast();
        VineDestroy();



    }

    void LaserRaycast()
    {
        if (fireLaser)
        {
            lr.enabled = true;
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
                        else if (hit.collider.GetComponent<Reflector>())
                        {
                            hit.collider.GetComponent<Laser>().fireLaser = true;
                            hit.collider.GetComponent<Reflector>().parentLaser = this;
                            reflector = hit.collider;
                        }


                        if (hit.collider.GetComponent<LaserActivation>())
                        {
                            hit.collider.GetComponent<LaserActivation>().isActivated = true;
                            hit.collider.GetComponent<LaserActivation>().parentLaser = this;

                            button = hit.collider;
                        }
                        else
                        {
                            button = null;
                        }


                        if (reflector)
                        {
                            if (hit.collider != reflector)
                            {
                                reflector.GetComponent<Laser>().fireLaser = false;
                                if (hit.collider.GetComponent<Reflector>())
                                {
                                    if (hit.collider.GetComponent<Reflector>().parentLaser)
                                    {
                                        hit.collider.GetComponent<Reflector>().parentLaser = null;
                                    }
                                }
  
                                
                                reflector = null;
                            }
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
            else
            {
                if (reflector)
                {
                    reflector.GetComponent<Laser>().fireLaser = false;
                    reflector = null;
                }
            }

        }
        else
        {

            lr.enabled = false;
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
                var pickupable = hit.transform.gameObject.AddComponent<Pickupable>();
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
