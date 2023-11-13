using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickaxe : Tool
{
    public float damage;
    public AudioClip pickHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnPickUp()
    {
        Debug.Log("pickup");
        transform.localRotation = Quaternion.Euler(rotation);
    }

    public override void Use()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, range))
        {
            Debug.Log(hit.collider.gameObject);
            if (hit.collider.CompareTag("Rock"))
            {
                hit.transform.localScale *= 0.9f;
                hit.transform.GetComponent<Rigidbody>().mass *= 0.9f;

                if(hit.transform.localScale.x <= 0.3f)
                {
                    hit.transform.gameObject.layer = 3;
                    var pickupable = hit.transform.AddComponent<Pickupable>();
                    pickupable.destroyOnPickup = true;
                    pickupable.dropOnSwitch = true;
                }

                GameObject rock = Instantiate(hit.collider.gameObject, hit.point, Quaternion.identity);
                rock.transform.localScale *= 0.1f;
                rock.GetComponent<Rigidbody>().mass *= 0.1f;
                rock.layer = 3;
                var pickupdable = rock.AddComponent<Pickupable>();
                pickupdable.destroyOnPickup = true;
                pickupdable.dropOnSwitch = true;

            }
            else if (hit.collider.CompareTag("ControlPanel"))
            {
                hit.collider.transform.gameObject.SetActive(false);
            }


            
        }
    }
}
