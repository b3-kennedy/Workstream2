using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            else if (holdPoint.childCount > 0 && hit.transform.GetComponent<ItemHolder>().CanPlace(holdPoint.GetChild(0).tag))
            {
                UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DROP);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Drop(hit.transform);
                }



            }



            //switch (hit.transform.tag)
            //{
            //    case "Fire":
            //        Debug.Log("hit fire");
            //        break;
            //    case "Water":
            //        break;
            //    case "Earth":
            //        break;
            //    case "Air":
            //        break;
            //    default:
            //        break;
            //}
        }
        else
        {
            UIManager.Instance.ChangeCrosshairState(UIManager.CrosshairState.DEFAULT);
        }
    }

    void Grab(Transform hitObj)
    {

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
        }
        else
        {
            Transform obj = Instantiate(hitObj, holdPoint);
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
    }

}
