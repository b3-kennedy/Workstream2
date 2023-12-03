using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{

    public Transform rayStart;
    public float range;
    public LayerMask interactableLayer;
    public Transform holdPoint;
    float tempDist = 9999;

    public GameObject pauseMenu;

    bool puzzle1;
    bool puzzle2;
    bool puzzle3;
    bool puzzle4;
    bool puzzle5;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Climb>().enabled = false;
    }

    void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.Instance.PauseMenu();
            if (UIManager.Instance.settingsPanel.activeSelf)
            {
                UIManager.Instance.CloseSettings();
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

        PauseMenu();





        if (GetComponent<Climb>().enabled)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<FirstPersonMovement>().enabled = true;
                GetComponent<Climb>().enabled = false;
            }
        }

        if (GameManager.Instance.playerCam.activeSelf)
        {
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
                                fire.transform.rotation = holdPoint.transform.rotation;
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
        }
        


        HeldItems();
        PuzzleResets();


    }

    void PuzzleResets()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (puzzle1)
            {
                GameManager.Instance.ResetPuzzle1();
                if(holdPoint.childCount > 0)
                {
                    Destroy(holdPoint.GetChild(0).gameObject);
                }
            }
            else if (puzzle2)
            {
                GameManager.Instance.ResetPuzzle2();
                if (holdPoint.childCount > 0)
                {
                    Destroy(holdPoint.GetChild(0).gameObject);
                }
            }
            else if (puzzle3)
            {
                GameManager.Instance.ResetPuzzle3();
                if (holdPoint.childCount > 0)
                {
                    Destroy(holdPoint.GetChild(0).gameObject);
                }
            }
            else if (puzzle4)
            {
                GameManager.Instance.ResetPuzzle4();
                if (holdPoint.childCount > 0)
                {
                    Destroy(holdPoint.GetChild(0).gameObject);
                }
            }
            else if (puzzle5)
            {
                GameManager.Instance.ResetPuzzle5();
                if (holdPoint.childCount > 0)
                {
                    Destroy(holdPoint.GetChild(0).gameObject);
                }
            }
        }
    }

    void HeldItems()
    {
        if (holdPoint.childCount > 0)
        {
            var heldItem = holdPoint.GetChild(0);
            if (heldItem.GetComponent<ElementalOrb>())
            {

                heldItem.GetComponent<ElementalOrb>().UI();

                if (Input.GetButtonDown("Fire1") && !UIManager.Instance.pauseMenu.activeSelf)
                {
                    heldItem.GetComponent<ElementalOrb>().Use();
                }

            }
            else if (heldItem.GetComponent<Tool>())
            {
                heldItem.GetComponent<Tool>().UI();
                if (Input.GetButtonDown("Fire1") && !UIManager.Instance.pauseMenu.activeSelf)
                {
                    heldItem.GetComponent<Tool>().Use();
                }
            }
            else if (heldItem.GetComponent<OrbOfPower>())
            {
                heldItem.GetComponent<LineRenderer>().enabled = true;
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

            if (heldItem.GetComponent<ElementalOrb>())
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.transform.GetComponent<ItemHolder>().CanPlace(ItemHolder.PrefferedObject.ELEMENT))
                    {
                        heldItem.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                        Drop(hit.transform);
                        heldItem.GetComponent<ElementalOrb>().enabled = false;
                    }
                    if (hit.transform.GetComponent<ItemHolder>().CanPlace(ItemHolder.PrefferedObject.FIRE))
                    {
                        if (heldItem.GetComponent<FireOrb>())
                        {
                            heldItem.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                            Drop(hit.transform);
                            heldItem.GetComponent<ElementalOrb>().enabled = false;
                        }

                    }
                    else if (hit.transform.GetComponent<ItemHolder>().CanPlace(ItemHolder.PrefferedObject.WATER))
                    {
                        if (heldItem.GetComponent<WaterOrb>())
                        {
                            heldItem.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                            Drop(hit.transform);
                            heldItem.GetComponent<ElementalOrb>().enabled = false;
                        }

                    }
                }

            }
            if (heldItem.CompareTag("Untagged"))
            {
                if (Input.GetKeyDown(KeyCode.E) && hit.transform.GetComponent<ItemHolder>().CanPlace(ItemHolder.PrefferedObject.DEFAULT))
                {
                    Drop(hit.transform);
                }
            }
            if (heldItem.CompareTag("Charcoal"))
            {
                if (Input.GetKeyDown(KeyCode.E) && hit.transform.GetComponent<ItemHolder>().CanPlace(ItemHolder.PrefferedObject.CHARCOAL))
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
        else if (other.CompareTag("Puzzle1"))
        {
            puzzle1 = true;
        }
        else if (other.CompareTag("Puzzle2"))
        {
            puzzle2 = true;
        }
        else if (other.CompareTag("Puzzle3"))
        {
            puzzle3 = true;
        }
        else if (other.CompareTag("Puzzle4"))
        {
            puzzle4 = true;
        }
        else if (other.CompareTag("Puzzle5"))
        {
            puzzle5 = true;
        }
        else if (other.CompareTag("AirUpgrade"))
        {
            GameManager.Instance.bonusAirTime += 5;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("EarthUpgrade"))
        {
            GameManager.Instance.bonusEarthTime += 0.1f;
            Destroy(other.gameObject);
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
        else if (other.CompareTag("Puzzle1"))
        {
            puzzle1 = false;
        }
        else if (other.CompareTag("Puzzle2"))
        {
            puzzle2 = false;
        }
        else if (other.CompareTag("Puzzle3"))
        {
            puzzle3 = false;
        }
        else if (other.CompareTag("Puzzle4"))
        {
            puzzle4 = false;
        }
        else if (other.CompareTag("Puzzle5"))
        {
            puzzle5 = false;
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
