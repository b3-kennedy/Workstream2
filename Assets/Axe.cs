using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Tool
{

    public Vector3 rotation;
    public float range;
    public AudioClip axeHit;

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

            if (hit.collider.CompareTag("Burnable"))
            {
                Destroy(hit.collider.gameObject);
                AudioSource.PlayClipAtPoint(axeHit, hit.point);
            }
        }
    }


}
