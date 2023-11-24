using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{

    public Transform rayStart;
    public float range;
    public LayerMask interactableLayer;
    public Transform holdPoint;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Climb>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(UIManager.Instance.enterText != null)
        {
            if (UIManager.Instance.enterText.gameObject.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    UIManager.Instance.HideText();
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }



        if (GetComponent<Climb>().enabled)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<FirstPersonMovement>().enabled = true;
                GetComponent<Climb>().enabled = false;
            }
        }

        if (Physics.Raycast(rayStart.position, Camera.main.transform.forward, out RaycastHit hit, range, interactableLayer))
        {

            

            if (hit.transform.GetComponent<Pickupable>())
            {
                UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.GRAB);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Grab(hit.transform);
                }
            }
            else if (hit.transform.GetComponent<EnvironmentElement>())
            {

                UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.GRAB);

                var elem = hit.transform.GetComponent<EnvironmentElement>().type;

                if (Input.GetKeyDown(KeyCode.E))
                {

                    if (holdPoint.childCount > 0)
                    {
                        var heldItem = holdPoint.GetChild(0);

                        if (heldItem.GetComponent<Pickupable>().dropOnSwitch)
                        {

                            heldItem.SetParent(null);
                            heldItem.GetComponent<Rigidbody>().isKinematic = false;
                            heldItem.GetComponent<Collider>().enabled = true;
                            
                        }
                        else
                        {
                            Destroy(heldItem.gameObject);
                        }
                    }



                    switch (elem)
                    {
                        case EnvironmentElement.ElementType.FIRE:

                            GameObject fire = Instantiate(Elements.Instance.fireOrb, holdPoint);
                            fire.transform.localPosition = Vector3.zero;
                            break;

                        case EnvironmentElement.ElementType.AIR:

                            GameObject air = Instantiate(Elements.Instance.airOrb, holdPoint);
                            air.transform.localPosition = Vector3.zero;
                            break;

                        case EnvironmentElement.ElementType.EARTH:

                            GameObject earth = Instantiate(Elements.Instance.earthOrb, holdPoint);
                            earth.transform.localPosition = Vector3.zero;
                            break;

                        case EnvironmentElement.ElementType.WATER:

                            GameObject water = Instantiate(Elements.Instance.waterOrb, holdPoint);
                            water.transform.localPosition = Vector3.zero;
                            break;

                        case EnvironmentElement.ElementType.STEAM:

                            GameObject steam = Instantiate(Elements.Instance.steamOrb, holdPoint);
                            steam.transform.localPosition = Vector3.zero;
                            break;

                        default:
                            break;
                    }
                }


            }
            else if (hit.transform.CompareTag("DoorButton"))
            {
                UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.GRAB);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.transform.GetComponent<DoorButton>())
                    {
                        hit.transform.GetComponent<DoorButton>().Activated();
                    }
                }

            }
            else if (holdPoint.childCount > 0)
            {
                var heldItem = holdPoint.GetChild(0);
                Debug.Log(hit.transform);
                Holders(hit, heldItem);



            }
        }
        else
        {
            if (UIManager.Instance)
            {
                UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DEFAULT);
            }
            
        }


        if (holdPoint.childCount > 0)
        {
            var heldItem = holdPoint.GetChild(0);
            if (heldItem.GetComponent<ElementalOrb>())
            {

                heldItem.GetComponent<ElementalOrb>().UI();

                if (Input.GetButtonDown("Fire1"))
                {
                    heldItem.GetComponent<ElementalOrb>().Use();
                }

            }
            else if (heldItem.GetComponent<Tool>())
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    heldItem.GetComponent<Tool>().Use();
                }
            }

            if (heldItem.GetComponent<Pickupable>().dropOnSwitch)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    heldItem.SetParent(null);
                    if (heldItem.GetComponent<Rigidbody>())
                    {
                        heldItem.GetComponent<Rigidbody>().isKinematic = false;
                        heldItem.GetComponent<Rigidbody>().AddForce(transform.forward * heldItem.GetComponent<Rigidbody>().mass * 100);
                    }

                    heldItem.GetComponent<Collider>().enabled = true;
                }
            }

        }


    }

    void Holders(RaycastHit hit, Transform heldItem)
    {
        if (hit.transform.GetComponent<ItemHolder>())
        {
            UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DROP);
            

            if (heldItem.CompareTag("Element"))
            {
                if (Input.GetKeyDown(KeyCode.E) && hit.transform.GetComponent<ItemHolder>().CanPlace(ItemHolder.PrefferedObject.ELEMENT))
                {
                    Drop(hit.transform);
                    heldItem.GetComponent<ElementalOrb>().enabled = false;
                }
            }
            if (heldItem.CompareTag("Untagged"))
            {
                if (Input.GetKeyDown(KeyCode.E) && hit.transform.GetComponent<ItemHolder>().CanPlace(ItemHolder.PrefferedObject.DEFAULT))
                {
                    Drop(hit.transform);
                }
            }
        }
    }


    void Grab(Transform hitObj)
    {

        if (hitObj.GetComponent<Buoyancy>())
        {
            hitObj.GetComponent<Buoyancy>().inWater = false;
        }

        if(holdPoint.transform.childCount > 0)
        {
            Transform heldObj = holdPoint.GetChild(0);

            heldObj.GetComponent<Collider>().enabled = false;

            if (heldObj.GetComponent<Pickupable>().dropOnSwitch)
            {
                heldObj.SetParent(null);
                heldObj.GetComponent<Rigidbody>().isKinematic = false;
                heldObj.GetComponent<Collider>().enabled = true;
            }
            else
            {
                Destroy(heldObj.gameObject);
            }
        }



        if (hitObj.GetComponent<Pickupable>().destroyOnPickup)
        {
            hitObj.SetParent(holdPoint);
            hitObj.localPosition = Vector3.zero;
            hitObj.GetComponent<Pickupable>().OnPickup();

            if (hitObj.GetComponent<Tool>())
            {
                hitObj.GetComponent<Tool>().OnPickUp();
            }

        }
        else
        {
            Transform obj = Instantiate(hitObj, holdPoint);
            if (obj.CompareTag("Element"))
            {
                obj.GetComponent<ElementalOrb>().enabled = true;
            }
            obj.localPosition = Vector3.zero;
            hitObj.GetComponent<Pickupable>().OnPickup();
        }
        UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DEFAULT);


    }

    void Drop(Transform hit)
    {
        Transform heldObject = holdPoint.GetChild(0);
        

        if (hit.transform.GetComponent<ItemHolder>().parentToChild)
        {
            heldObject.SetParent(hit.transform.GetChild(0));
        }
        else
        {
            heldObject.SetParent(hit.transform);
        }

        heldObject.localPosition = Vector3.zero;
        UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DEFAULT);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StartClimb"))
        {
            
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<FirstPersonMovement>().enabled = false;
            GetComponent<Climb>().enabled = true;
        }
        else if (other.CompareTag("EndClimb"))
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<FirstPersonMovement>().enabled = true;
            GetComponent<Climb>().enabled = false;
        }
        else if (other.CompareTag("WaterArea"))
        {
            GetComponent<Swim>().enabled = true;
            GetComponent<Rigidbody>().drag = GetComponent<Swim>().swimDrag;

        }
        else if (other.CompareTag("AirTowerDoor"))
        {
            UIManager.Instance.ShowText();
        }
        else if (other.CompareTag("Exit"))
        {
            SceneManager.LoadScene("Island", LoadSceneMode.Additive);
        }
        else if (other.GetComponent<PortalDoor>())
        {
            transform.position = other.GetComponent<PortalDoor>().destination.position;
        }
        else if (other.CompareTag("CaveEntrance"))
        {
            transform.position = GameManager.Instance.caveEntrancePont.position;
            //light off
            GameManager.Instance.directionalLight.SetActive(false);
            RenderSettings.ambientLight = Color.black;
            RenderSettings.skybox = GameManager.Instance.blackSkybox;
            DynamicGI.UpdateEnvironment();
        }
        else if (other.CompareTag("CaveExit"))
        {
            transform.position = GameManager.Instance.caveExitPoint.position;
            //light off
            GameManager.Instance.directionalLight.SetActive(false);
            RenderSettings.ambientLight = Color.black;
            RenderSettings.skybox = GameManager.Instance.blackSkybox;
            DynamicGI.UpdateEnvironment();



        }
        else if (other.CompareTag("TerrainEntrance"))
        {
            transform.position = GameManager.Instance.caveTerrainEntrance.position;
            //light on
            GameManager.Instance.directionalLight.SetActive(true);
            RenderSettings.ambientLight = GameManager.Instance.defaultAmbience;
            RenderSettings.skybox = GameManager.Instance.defaultSkybox;
            DynamicGI.UpdateEnvironment();
        }
        else if (other.CompareTag("TerrainExit"))
        {
            transform.position = GameManager.Instance.caveTerrainExit.position;
            //light on
            GameManager.Instance.directionalLight.SetActive(true);
            RenderSettings.ambientLight = GameManager.Instance.defaultAmbience;
            RenderSettings.skybox = GameManager.Instance.defaultSkybox;
            DynamicGI.UpdateEnvironment();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WaterArea"))
        {
            GetComponent<Swim>().enabled = false;
            GetComponent<Rigidbody>().drag = 0;
        }
        else if (other.CompareTag("AirTowerDoor"))
        {
            UIManager.Instance.HideText();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("ClimbableVines"))
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<FirstPersonMovement>().enabled = false;
            GetComponent<Climb>().enabled = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("ClimbableVines"))
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<FirstPersonMovement>().enabled = true;
            GetComponent<Climb>().enabled = false;
        }

    }

}
